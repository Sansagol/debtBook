//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;
//using System.Windows.Input;
//using Xamarin.Forms;

//namespace DebtBook.Core.Behaviours
//{

//    public class EventToCommand : Behavior<View>
//    {
//        Delegate EventHandler = null;
//        public View AssociatedObject { get; private set; }

//        public static readonly BindableProperty CommandProperty =
//            BindableProperty.Create(
//                "Command",
//                typeof(ICommand),
//                typeof(EventToCommand));
//        public static readonly BindableProperty EventNameProperty =
//            BindableProperty.Create(
//                "EventName",
//                typeof(string),
//                typeof(EventToCommand));



//        public ICommand Command
//        {
//            get { return (ICommand)GetValue(CommandProperty); }
//            set { SetValue(CommandProperty, value); }
//        }

//        public string EventName
//        {
//            get { return (string)GetValue(EventNameProperty); }
//            set { SetValue(EventNameProperty, value); }
//        }

//        protected override void OnAttachedTo(View bindable)
//        {
//            base.OnAttachedTo(bindable);
//            AssociatedObject = bindable;
//            if (bindable.BindingContext != null)
//            {
//                BindingContext = bindable.BindingContext;
//            }
//            bindable.BindingContextChanged += Bindable_BindingContextChanged;
//            RegisterEvent(EventName);
//        }

//        private void Bindable_BindingContextChanged(object sender, EventArgs e)
//        {
//            OnBindingContextChanged();
//        }

//        protected override void OnBindingContextChanged()
//        {
//            base.OnBindingContextChanged();
//            BindingContext = AssociatedObject.BindingContext;
//        }

//        protected override void OnDetachingFrom(View bindable)
//        {
//            DeregisterEvent(EventName);
//            base.OnDetachingFrom(bindable);

//            bindable.BindingContextChanged -= Bindable_BindingContextChanged;
//            AssociatedObject = null;
//        }

//        private void RegisterEvent(string eventName)
//        {
//            if (string.IsNullOrWhiteSpace(eventName))
//                throw new ArgumentNullException(nameof(eventName));

//            EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(eventName);
//            if (eventInfo == null)
//            {
//                throw new ArgumentException(string.Format("EventToCommandBehavior: Can't register the '{0}' event.", EventName));
//            }
//            MethodInfo methodInfo = typeof(EventToCommand).GetTypeInfo().GetDeclaredMethod("OnEvent");
//            EventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
//            eventInfo.AddEventHandler(AssociatedObject, EventHandler);
//        }

//        void OnEvent(object sender, object eventArgs)
//        {
//            if (Command == null)
//            {
//                return;
//            }

//            object resolvedParameter;
//            //if (CommandParameter != null)
//            //{
//            //    resolvedParameter = CommandParameter;
//            //}
//            //else if (Converter != null)
//            //{
//            //    resolvedParameter = Converter.Convert(eventArgs, typeof(object), null, null);
//            //}
//            //else
//            {
//                resolvedParameter = eventArgs;
//            }

//            if (Command.CanExecute(resolvedParameter))
//            {
//                Command.Execute(resolvedParameter);
//            }
//        }

//        void DeregisterEvent(string name)
//        {
//            if (string.IsNullOrWhiteSpace(name))
//            {
//                return;
//            }

//            if (EventHandler == null)
//            {
//                return;
//            }
//            EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
//            if (eventInfo == null)
//            {
//                throw new ArgumentException(string.Format("EventToCommandBehavior: Can't de-register the '{0}' event.", EventName));
//            }
//            eventInfo.RemoveEventHandler(AssociatedObject, EventHandler);
//            EventHandler = null;
//        }

//    }
//}
