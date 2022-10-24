using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene16 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Karim = storyInformator.Karim;

            Scene(storyInformator.KarimRoom);

            Show(Skull, PositionOnTheStage.Left);
            Show(Karim, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Karim, "��� ������������� ���� ������� �������������. � ������ ����� �����." +
                " ����������� � ����� ������������.", "");

            await Say(Skull, "��������� � ����, ���� �� ����� ������.", "");

            Fork();
        }
    }
}