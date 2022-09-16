namespace FractalTree;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        double degrees = args.NewValue;
        displayLabel.Text = String.Format("The angle is {0}° degrees", degrees);

        ((FractalTreeDrawable)fractalTreeView.Drawable).DeltaAngle = degrees * (Math.PI / 180);
        fractalTreeView.Invalidate();
    }
}