using System.CodeDom;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Invert.uFrame.MVVM {
    using System;
    
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Invert.Core;
    using Invert.Core.GraphDesigner;
    
    
    public class uFrameMVVM : uFrameMVVMBase {

        public static Invert.Core.RegisteredInstance[] BindingTypes { get; set; }
        public override Invert.Core.GraphDesigner.SelectItemTypeCommand GetCommandsSelectionCommand() {
            base.GetCommandsSelectionCommand();
            return new SelectItemTypeCommand() { IncludePrimitives = true, AllowNone = true };
        }
        
        public override Invert.Core.GraphDesigner.SelectItemTypeCommand GetPropertiesSelectionCommand() {
            base.GetPropertiesSelectionCommand();
            return new SelectItemTypeCommand() { IncludePrimitives = true, AllowNone = false };
        }
        
        public override Invert.Core.GraphDesigner.SelectItemTypeCommand GetCollectionsSelectionCommand() {
            base.GetCollectionsSelectionCommand();
            return new SelectItemTypeCommand() { IncludePrimitives = true, AllowNone = false };
        }
        
        public override void Initialize(Invert.Core.uFrameContainer container) {
            base.Initialize(container);
            //BindingTypes = InvertGraphEditor.Container.Instances.Where(p => p.Base == typeof(uFrameBindingType)).ToArray();
        }

        public override void Loaded(uFrameContainer container)
        {
            base.Loaded(container);
            MVVM.HasSubNode<ServiceNode>();
            MVVM.HasSubNode<SimpleClassNode>();
            MVVM.HasSubNode<TypeReferenceNode>();
            MVVM.Name = "MVVM Kernel Graph";
            ComputedProperty.Name = "Computed Property";
            Subsystem.HasSubNode<TypeReferenceNode>();
            Element.HasSubNode<TypeReferenceNode>();
            Subsystem.HasSubNode<EnumNode>();
            Element.HasSubNode<EnumNode>();
            Service.HasSubNode<EnumNode>();
            Service.HasSubNode<SimpleClassNode>();
            Service.HasSubNode<TypeReferenceNode>();
            SceneType.Name = "Scene Type";
            Subsystem.Name = "Sub System";
            Service.Name = "Service";
            ViewComponent.Name = "View Component";
            StateMachine.Name = "State Machine";
            BindingTypes = InvertGraphEditor.Container.Instances.Where(p => p.Base == typeof(uFrameBindingType)).ToArray();
            container.AddItemFlag<CommandsChildItem>("Publish", Color.green);
        }
    }
    public static class uFramePluginContainerExtensions
    {
        public static uFrameBindingType AddBindingMethod(this IUFrameContainer container, Type type, MethodInfo method, Func<ITypedItem, bool> canBind)
        {
            return AddBindingMethod(container, new uFrameBindingType(type, method, canBind), method.Name);
        }
        public static uFrameBindingType AddBindingMethod(this IUFrameContainer container, Type type, string methodName, Func<ITypedItem, bool> canBind)
        {
            return AddBindingMethod(container, new uFrameBindingType(type, methodName, canBind), methodName);
        }

        public static uFrameBindingType AddBindingMethod(this IUFrameContainer container, uFrameBindingType info,
            string name)
        {
            container.RegisterInstance<uFrameBindingType>(info, name);
            return info;
        }
    }
    public class uFrameBindingType
    {
        private string _displayFormat = "{0}";
        public Action<BindingHandlerArgs> HandlerImplementation { get; set; }

        public string DisplayFormat
        {
            get { return _displayFormat; }
            set { _displayFormat = value; }
        }

        public string Description { get; set; }
        public Type Type { get; set; }
        public MethodInfo MethodInfo { get; set; }
        public Func<ITypedItem, bool> CanBind { get; set; }
        public static Type ObservablePropertyType { get; set; }
        public static Type ObservableCollectionType { get; set; }
        public static Type UFGroupType { get; set; }
        public static Type ICommandType { get; set; }

        public uFrameBindingType SetNameFormat(string format)
        {
            DisplayFormat = format;
            return this;
        }
        public uFrameBindingType SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public uFrameBindingType ImplementWith(Action<BindingHandlerArgs> implement)
        {
            HandlerImplementation = implement;
            return this;
        }
        public uFrameBindingType(Type type, string methodFormat, Func<ITypedItem, bool> canBind)
        {
            Type = type;
            CanBind = canBind;
            DisplayFormat = methodFormat;
            MethodInfo = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(p => !p.IsDefined(typeof(ObsoleteAttribute), true) && p.Name == methodFormat);
            if (MethodInfo == null)
            {
                throw new Exception(String.Format("Couldn't register binding for method {0}.{1} because it was not found", type.Name, methodFormat));
            }
        }

        public uFrameBindingType(Type type, MethodInfo methodInfo, Func<ITypedItem, bool> canBind)
        {
            Type = type;
            MethodInfo = methodInfo;
            CanBind = canBind;
            DisplayFormat = methodInfo.Name;
            //Description
        }

        public CodeExpression CreateBindingSignature(CreateBindingSignatureParams createBindingSignatureParams)
        {
            var elementName = createBindingSignatureParams.ElementView.Element.Name;
            var propertyName = string.Format(createBindingSignatureParams.SubscribablePropertyNameFormat, createBindingSignatureParams.SourceItem.Name);
            var name = createBindingSignatureParams.SourceItem.Name;

            var methodInvoke = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), MethodInfo.Name);
            
            var isExtensionMethod = MethodInfo.IsDefined(typeof(ExtensionAttribute), true);

            for (int index = 0; index < MethodInfo.GetParameters().Length; index++)
            {
                var parameter = MethodInfo.GetParameters()[index];
                if (isExtensionMethod && index == 0) continue;

                var genericArguments = parameter.ParameterType.GetGenericArguments();
                if (typeof(Delegate).IsAssignableFrom(parameter.ParameterType))
                {
                    var method = CreateDelegateMethod(createBindingSignatureParams.ConvertGenericParameter, parameter, genericArguments, propertyName, name);

                    methodInvoke.Parameters.Add(new CodeSnippetExpression(String.Format((string)"this.{0}", (object)method.Name)));
                    createBindingSignatureParams.Context.Members.Add(method);
                    if (HandlerImplementation != null && !createBindingSignatureParams.DontImplement)
                    {
                        HandlerImplementation(new BindingHandlerArgs() { View = createBindingSignatureParams.ElementView, SourceItem = createBindingSignatureParams.SourceItem, Method = method, Decleration = createBindingSignatureParams.Context });
                    }
                    if (createBindingSignatureParams.DontImplement)
                    {
                        method.Attributes |= MemberAttributes.Override;
                    }
                    createBindingSignatureParams.Ctx.AddMemberOutput(createBindingSignatureParams.BindingsReference,
                        new TemplateMemberResult(null,
                            null,
                            new TemplateMethod(MemberGeneratorLocation.Both), 
                            method,
                            createBindingSignatureParams.Ctx.CurrentDecleration));
                }
                else if (typeof(ICollection).IsAssignableFrom(parameter.ParameterType))
                {
                    methodInvoke.Parameters.Add(new CodeSnippetExpression(String.Format("this.{0}.{1}", elementName, createBindingSignatureParams.SourceItem.Name)));
                }
                else if (ObservablePropertyType.IsAssignableFrom(parameter.ParameterType))
                {
                    methodInvoke.Parameters.Add(new CodeSnippetExpression(String.Format("this.{0}.{1}", elementName, propertyName)));
                }
                else if (ICommandType.IsAssignableFrom(parameter.ParameterType))
                {
                    methodInvoke.Parameters.Add(new CodeSnippetExpression(String.Format("this.{0}.{1}", elementName, createBindingSignatureParams.SourceItem.Name)));
                }
                else if (!createBindingSignatureParams.DontImplement)
                {
                    var parameterName = parameter.Name.Substring(0, 1).ToUpper() + parameter.Name.Substring(1);
                    var field = createBindingSignatureParams.Context._protected_(parameter.ParameterType, "_{0}{1}", name, parameterName);
                    field.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(UFGroupType),
                        new CodeAttributeArgument(new CodePrimitiveExpression(name))));

                    field.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(typeof(SerializeField))));
                    field.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(typeof(HideInInspector))));
                    methodInvoke.Parameters.Add(new CodeSnippetExpression(field.Name));

                    field.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(typeof(FormerlySerializedAsAttribute)),
                        new CodeAttributeArgument(new CodePrimitiveExpression(string.Format("_{0}{1}",name, parameter.Name)))));
                 
                }
            }
            
            return methodInvoke;
        }

        public CodeMemberMethod CreateDelegateMethod(Func<Type, CodeTypeReference> convertGenericParameter, ParameterInfo parameter, Type[] genericArguments, string propertyName, string name)
        {
            var method = new CodeMemberMethod()
            {
                Name = String.Format("{0}{1}{2}", name, parameter.Name.Substring(0, 1).ToUpper(), parameter.Name.Substring(1)),
                Attributes = MemberAttributes.Public
            };
            var isFunc = parameter.ParameterType.Name.Contains("Func");
            if (isFunc)
            {
                var returnType = genericArguments.LastOrDefault();
                if (returnType != null)
                {
                    method.ReturnType = new CodeTypeReference(returnType);
                }
            }
            var index = 1;
            foreach (var item in genericArguments)
            {
                if (isFunc && item == genericArguments.Last()) continue;
                var type = item;
                if (item.IsGenericParameter)
                {
                    method.Parameters.Add(new CodeParameterDeclarationExpression(convertGenericParameter(item), String.Format("arg{0}", index)));
                }
                else
                {
                    method.Parameters.Add(new CodeParameterDeclarationExpression(type, String.Format("arg{0}", index)));
                }

            }
            return method;
        }

        public static void CreateActionSignature(Type actionType)
        {

        }
    }

    public class CreateBindingSignatureParams
    {
        private CodeTypeDeclaration _context;
        private Func<Type, CodeTypeReference> _convertGenericParameter;
        private ViewNode _elementView;
        private ITypedItem _sourceItem;
        private string _subscribablePropertyNameFormat;

        public CreateBindingSignatureParams(CodeTypeDeclaration context, Func<Type, CodeTypeReference> convertGenericParameter, ViewNode elementView, ITypedItem sourceItem, string subscribablePropertyNameFormat = "{0}Property")
        {
            _context = context;
            _convertGenericParameter = convertGenericParameter;
            _elementView = elementView;
            _sourceItem = sourceItem;
            _subscribablePropertyNameFormat = subscribablePropertyNameFormat;
        }

        public CodeTypeDeclaration Context
        {
            get { return _context; }
        }

        public Func<Type, CodeTypeReference> ConvertGenericParameter
        {
            get { return _convertGenericParameter; }
        }

        public ViewNode ElementView
        {
            get { return _elementView; }
        }

        public ITypedItem SourceItem
        {
            get { return _sourceItem; }
        }

        public string SubscribablePropertyNameFormat
        {
            get { return _subscribablePropertyNameFormat; }
        }

        public TemplateContext<ViewNode> Ctx { get; set; }
        public bool DontImplement { get; set; }
        public BindingsReference BindingsReference { get; set; }
    }

    public class BindingHandlerArgs
    {

        /// <summary>
        /// The method that should be properly decorated for the implementation
        /// </summary>
        public CodeMemberMethod Method { get; set; }

        /// <summary>
        /// The view that owns this binding.
        /// </summary>
        public ViewNode View { get; set; }

        /// <summary>
        /// The element that belongs to the view that has the binding.
        /// </summary>
        public ElementNode Element { get { return View.Element; } }
        /// <summary>
        /// The item being bound to, Property, Collection or Command.
        /// </summary>
        public ITypedItem SourceItem { get; set; }
        /// <summary>
        /// The current decleration at which the binding is being created inside.  Ie: The View class
        /// </summary>
        public CodeTypeDeclaration Decleration { get; set; }
    }
}
