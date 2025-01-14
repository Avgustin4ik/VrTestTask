namespace Code.Models
{
    public interface IInput
    {
        void OnClick();
        void OnDrag();
        void OnDrop();
        void OnHover();
        void OnUnhover();
    }
}