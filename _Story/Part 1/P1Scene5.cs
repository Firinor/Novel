using UnityEngine;

namespace FirGames.StoryPart1
{
    public class P1Scene5 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "������ ����, ��� ��� - ��������. ���� ������� ������� �� ����, ��� ������ �������� �������.", "");

            await Say(Skull, "��������-���� ���������� � �������, �� �� ����������� ���� ������� ������.", "");

            await Say(Skull, "������� ���� ��������� ������ ����� ��������� �������, �� ������ �� �� ������� ����� � ������, " +
                "� �� ������� ���� ������ ������ � ��, ���� ����� ������ �� �������. �����������?", "");

            await Say(Skull, "��� ���� �� ���-������ �� ������ ��������� ���������� ������� ������ �� ������� �� ������� �� " +
                "�� ����������, ��� ����� �� ������ �������� �� ����������� ���.", "");

            await Say(Skull, "��� ��� �������, �� ���� ��������� ������ ������?", "");

            Fork();
        }
    }
}