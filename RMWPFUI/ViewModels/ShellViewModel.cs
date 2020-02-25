using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using RMWPFUI.EventModels;

namespace RMWPFUI.ViewModels
{
    public class ShellViewModel:Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesView;
        private SimpleContainer _container;

        public ShellViewModel(IEventAggregator events,SalesViewModel salesView
            ,SimpleContainer container)
        {
            _events = events;
            _events.Subscribe(this);

            _salesView = salesView;
            _container = container;

            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesView);
        }
    }
}
