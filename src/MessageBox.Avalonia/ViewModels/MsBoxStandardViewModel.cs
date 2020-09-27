using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using MessageBox.Avalonia.Views;
using System;

namespace MessageBox.Avalonia.ViewModels
{
    public class MsBoxStandardViewModel : AbstractMsBoxViewModel
    {
        private MsBoxStandardWindow _window;
        public string ContentMessage { get; }
        public bool IsOkShowed { get; private set; }
        public bool IsYesShowed { get; private set; }
        public bool IsNoShowed { get; private set; }
        public bool IsAbortShowed { get; private set; }
        public bool IsCancelShowed { get; private set; }

        public MsBoxStandardViewModel(MessageBoxStandardParams @params, MsBoxStandardWindow msBoxStandardWindow) : base(@params)
        {
            ContentMessage = @params.ContentMessage;
            _window = msBoxStandardWindow;
            SetButtons(@params.ButtonDefinitions);
        }

        private void SetButtons(ButtonEnum paramsButtonDefinitions)
        {
            switch (paramsButtonDefinitions)
            {
                case ButtonEnum.Ok:
                    IsOkShowed = true;
                    break;
                case ButtonEnum.YesNo:
                    IsYesShowed = true;
                    IsNoShowed = true;
                    break;
                case ButtonEnum.OkCancel:
                    IsOkShowed = true;
                    IsCancelShowed = true;
                    break;
                case ButtonEnum.OkAbort:
                    IsOkShowed = true;
                    IsAbortShowed = true;
                    break;
                case ButtonEnum.YesNoCancel:
                    IsYesShowed = true;
                    IsNoShowed = true;
                    IsCancelShowed = true;
                    break;
                case ButtonEnum.YesNoAbort:
                    IsYesShowed = true;
                    IsNoShowed = true;
                    IsAbortShowed = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(paramsButtonDefinitions), paramsButtonDefinitions,
                        null);
            }
        }

        public void ButtonClick(string parameter)
        {
            _window.ButtonResult = (ButtonResult)Enum.Parse(typeof(ButtonResult), parameter.Trim(), false);
            _window.Close();
        }
    }
}