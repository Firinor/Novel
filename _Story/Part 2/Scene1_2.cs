using UnityEngine;

namespace FirGames.StoryPart2
{
    public class Scene1_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Varus = storyInformator.Varus;
            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Memorial);

            Show(Skull, PositionOnTheStage.Left);
            Show(Varus, PositionOnTheStage.Center);

            await Say(Skull, "����������� ������ ��������� ����� �����, � � ��� ����� ���������," +
                " ��� ������ ����� ������ �������� ����� 15 ���� ����� ������ �����������, �� ������.", "");

            await Say(Varus, "� ���� ������! ����� 15 ����," +
                " ���� ������� ������ �� �������� ������� �������, �� ��������� ������ ��-�������.", "");

            Fork();
        }
    }
}