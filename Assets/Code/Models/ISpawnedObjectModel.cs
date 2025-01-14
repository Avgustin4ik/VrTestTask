namespace Code.Models
{
    public interface ISpawnedObjectModel : IObjectModel
    {
        void Edit();
        void Despawn();
        void PlayAnimation(int animationHash);
    }
}