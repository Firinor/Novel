using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static StoryInformator;

public enum PositionOnTheStage { OffScene, Left, Center, Right}
public enum DialogProgressStatus { Open, Closed, Hiden }

public class DialogNode : MonoBehaviour
{
    [SerializeField]
    private string[] Header = new string[2] { "русское название", "english name" };
    [SerializeField]
    private List<DialogNode> Choices;
    private DialogProgressStatus dialogProgressStatus = DialogProgressStatus.Hiden;

    protected DialogOperator dialogOperator;
    protected Characters Characters;
    protected Backgrounds Backgrounds;

    protected void Awake()
    {
        StoryInformator storyInformator = StoryInformator.instance;
        Characters = storyInformator.characters;
        Backgrounds = storyInformator.backgrounds;
        dialogOperator = DialogOperator.instance;
        GetComponent<Button>().onClick.AddListener(StartDialog);
    }
    public void SetChoice(DialogNode dialogNode)
    {
        if (dialogNode == null)
            return;

        Choices = new List<DialogNode>() { dialogNode };
    }
    public string GetHeader()
    {
        return Header[(int)PlayerManager.Language];
    }
    public virtual void StartDialog()
    {
        DialogManager.ActivateDialog(GetComponent<RectTransform>());
        dialogOperator.CleareAll();
        dialogOperator.SetSceneName(name);
    }

    public void StartDialog(int index)
    {
        if(Choices != null && Choices.Count > index)
            Choices[index]?.StartDialog();
    }

    public void Fork(bool soloButton = false)
    {
        if (DialogManager.IsCancellationRequested)
        {
            StopDialogSkip();
            return;
        }

        if (Choices == null || Choices.Count < 1)
        {
            StopDialogSkip();
            dialogOperator.DialogExit();
            return;
        }

        if (!soloButton && Choices.Count == 1)
        {
            Choices[0].StartDialog();
            return;
        }

        StopDialogSkip();
        for (int i = 0; i < Choices.Count; i++)
        {
            //dialogOperator.CreateWayButton(Choices[i]);
        }
    }

    protected void StopDialogSkip()
    {
        if(dialogOperator != null)
            dialogOperator.StopDialogSkip();
    }

    [ContextMenu("Reset name")]
    public void ResetName()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = gameObject.name;
    }
}
