namespace AuctionApp.Layouts
{
    public interface ILayoutManager
    {
        object BindingContext { get; set; }

        void SetPosition(BindableObject bindableObject, int position);
    }
}
