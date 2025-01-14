namespace Code.Models
{
    using UnityEngine;

    public interface IEditableObjectModel : IObjectModel
    {
        void Cancel();
        bool TryConfirm();
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
    }
}