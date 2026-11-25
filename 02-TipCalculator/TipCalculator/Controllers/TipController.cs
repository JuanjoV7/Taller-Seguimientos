using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.Models;
using TipCalculator.Views;

namespace TipCalculator.Controllers
{
    public class TipController
    {
        private TipView _view;

        public TipController()
        {
            _view = new TipView();
        }

        public void Run()
        {
            int option = -1;

            while (option != 0)
            {
                option = _view.ShowMenu();

                switch (option)
                {
                    case 1:
                        CalculateBill();
                        break;
                    case 0:
                        _view.ShowMessage("Hasta luego.");
                        break;
                    default:
                        _view.ShowMessage("Opción no válida.");
                        break;
                }
            }
        }

        private void CalculateBill()
        {
            decimal total = _view.ReadTotal();

            if (total <= 0)
            {
                _view.ShowMessage("El monto debe ser mayor a 0.");
                return;
            }

            int percentageOption = _view.ReadPercentageOption();
            decimal percentage = 0;

            switch (percentageOption)
            {
                case 1:
                    percentage = 10;
                    break;
                case 2:
                    percentage = 15;
                    break;
                case 3:
                    percentage = 20;
                    break;
                case 4:
                    percentage = _view.ReadCustomPercentage();
                    break;
                default:
                    _view.ShowMessage("Opción no válida.");
                    return;
            }

            if (percentage < 0)
            {
                _view.ShowMessage("El porcentaje no puede ser negativo.");
                return;
            }

            Bill bill = new Bill(total, percentage);
            _view.ShowResult(bill);
        }
    }
}
