using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;

using System.Threading.Tasks;
using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateStart : UserControl
    {
        private IDispatcher _dispatcher;

        public UserInterfaceStateStart(IDispatcher dispatcher)
        {
            InitializeComponent();

            _dispatcher = dispatcher;
        }
    }
}
