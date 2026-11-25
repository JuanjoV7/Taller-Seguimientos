using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordGenerator.Models;
using PasswordGenerator.Views;

namespace PasswordGenerator.Controllers
{
    public class PasswordController
    {
        private PasswordView _view;

        public PasswordController()
        {
            _view = new PasswordView();
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
                        GeneratePassword();
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

        private void GeneratePassword()
        {
            int length = _view.ReadLength();

            if (length < 8 || length > 64)
            {
                _view.ShowMessage("La longitud debe estar entre 8 y 64 caracteres.");
                return;
            }

            bool useUppercase = _view.ReadYesNo("¿Incluir letras mayúsculas? (s/n): ");
            bool useLowercase = _view.ReadYesNo("¿Incluir letras minúsculas? (s/n): ");
            bool useNumbers = _view.ReadYesNo("¿Incluir números? (s/n): ");
            bool useSymbols = _view.ReadYesNo("¿Incluir símbolos? (s/n): ");

            Password password = new Password(length, useUppercase, useLowercase, useNumbers, useSymbols);

            if (!password.HasCharacterTypes())
            {
                _view.ShowMessage("Debe seleccionar al menos un tipo de caracter.");
                return;
            }

            _view.ShowPassword(password.Generate());
        }
    }
}
