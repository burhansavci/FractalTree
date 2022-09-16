namespace FractalTree;

public class FractalTreeDrawable : IDrawable
{
    public double Angle = Math.PI * -0.5; //90 degrees
    public double DeltaAngle = 0.7;
    private double Length = 120;
    private readonly double Shrink = 0.67;
    private int Level = 0;
    private static readonly int MaxLevel = 10;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        var coordinateX = dirtyRect.Center.X;
        var coordinateY = dirtyRect.Center.Y + dirtyRect.Center.Y / 2;

        canvas.StrokeColor = Colors.Aqua;
        canvas.StrokeSize = 6;

        DrawBranches(canvas, coordinateX, coordinateY, Angle, Length, Level);
    }

    private void DrawBranches(ICanvas canvas, float coordinateX, float coordinateY, double angle, double length, int level)
    {
        //Calculate next point
        var dXPosition = length * Math.Cos(angle);
        var dYPosition = length * Math.Sin(angle);
        var nextX = coordinateX + dXPosition;
        var nextY = coordinateY + dYPosition;
       
        //Draw the branch
        canvas.DrawLine(coordinateX, coordinateY, (float)nextX, (float)nextY);

        if (++level < MaxLevel)
        {
            //Next right branch
            length *= Shrink;
            angle += DeltaAngle;
            canvas.StrokeColor = Colors.Red;
            DrawBranches(canvas, (float)nextX, (float)nextY, angle, length, level);

            //Next left branch
            angle -= DeltaAngle * 2; // Change branch position from this "/" to this "\"
            canvas.StrokeColor = Colors.Green;
            DrawBranches(canvas, (float)nextX, (float)nextY, angle, length, level);
        }
    }
}