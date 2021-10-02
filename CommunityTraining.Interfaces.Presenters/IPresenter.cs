using System;

namespace CommunityTraining.Interfaces.Presenters
{
    public interface IPresenter<FormatDataType>
    {
        public FormatDataType Content { get; }
    }
}
