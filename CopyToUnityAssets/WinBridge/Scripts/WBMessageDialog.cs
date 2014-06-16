using UnityEngine;
using System.Collections;
using WinControls;

[ExecuteInEditMode]
[AddComponentMenu("WinBridge/MessageDialog")]

public class WBMessageDialog : MonoBehaviour {

    public string title = "";
    public string label = "";

    public string firstCommandLabel;
    public GameObject firstCommandReceivingObject;
    public string firstCommandMethod;
    public string secondCommandLabel;
    public GameObject secondCommandRecievingObject;
    public string secondCommandMethod;

    [HideInInspector][SerializeField] public delegate void firstCommandDelegate();
    firstCommandDelegate _firstCommandDelegate;
    [HideInInspector][SerializeField] public delegate void secondCommandDelegate();
    secondCommandDelegate _secondCommandDelegate;

    private MessageBox _messageBox;
    private MessageBox.Command _command1 = null;
    private MessageBox.Command _command2 = null;

	void SetupCommands () {
        if (firstCommandMethod != null && firstCommandReceivingObject != null)
        {
            if (firstCommandLabel != null && firstCommandLabel != "")
            {
                _firstCommandDelegate = delegate { firstCommandReceivingObject.SendMessage(firstCommandMethod); };
                _command1 = new MessageBox.Command(firstCommandLabel, firstCommand);
            }
        }
        if (secondCommandMethod != null && secondCommandRecievingObject != null)
        {
            if (secondCommandLabel != null && secondCommandLabel != "")
            {
                _secondCommandDelegate = delegate { secondCommandRecievingObject.SendMessage(secondCommandMethod); };
                _command2 = new MessageBox.Command(secondCommandLabel, secondCommand);
            }
        }
	}

    public void Show()
    {
		_messageBox = new WinControls.MessageBox();

         SetupCommands();

        if (_command1 != null && _command2 != null)
        {
            _messageBox.ShowMessageBox(label, title, _command1, _command2);
        }
        else if (_command1 != null && _command2 == null)
        {
            _messageBox.ShowMessageBox(label, title, _command1, null);
        }
        else if (_command1 == null && _command2 == null)
        {
            _messageBox.ShowMessageBox(label, title, null, null);
        }
        #if NETFX_CORE
        Debug.Log("WinBridge: Showing native WinRT MessageDialog");
        #elif UNITY_METRO || UNITY_WINRT || UNITY_EDITOR
        Debug.Log("WinBridge: Showing native WinRT MessageDialog (only visible if compiled with Visual Studio for Windows Store)");
        #endif
    }

    void firstCommand(object UICommand)
    {
        _firstCommandDelegate();
    }

    void secondCommand(object UICommand)
    {
        _secondCommandDelegate();
    }

}
 