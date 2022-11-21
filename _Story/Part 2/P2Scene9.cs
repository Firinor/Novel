using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene9 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Karim = Characters.Karim;

            Scene(Backgrounds.Quarry);

            Show(Skull, PositionOnTheStage.Left);
            Show(Karim, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "������� �������. ��� � ��� ���� ������� ���������� �����������.", "");

            await Say(Karim, "������ ��� ���� ���� ����� �� �����-���� ������� " +
                "� ������ ��������� � ������ ������ ��������������.", "");

            await Say(Skull, "����� �� ��� �� ������� ���� ������� ������.", "");

            await Say(Karim, "�����. ��� ��� ������������.", "");

            await ShowImage(SpecialImages.TwoDaysHavePassed);

            Fork();
        }
    }
}