using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene14_3_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator LordCarlos = Characters.LordCarlos;

            Scene(Backgrounds.Office);

            Show(Skull, PositionOnTheStage.Left);
            Show(LordCarlos, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "�� � �������� ������ ���� ���� �� ��������, ��������� ����� �������� �� �����.", "");

            await Say(LordCarlos, "�������! ���� ������ ������ �� �� ��������.", "");

            await Say(Skull, "���� ��� �������� � ����� ������ ��������� ���� ���� ���������.", "");

            Fork();
        }
    }
}