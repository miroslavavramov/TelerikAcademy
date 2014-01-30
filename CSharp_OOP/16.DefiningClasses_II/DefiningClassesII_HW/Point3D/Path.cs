using System;
using System.Collections.Generic;
using System.Text;
class Path
{
    private List<Point3D> path;

    public Point3D this[int index]  //indexer
    {
        get { return this.path[index]; }
    }

    public int Count
    {
        get { return this.path.Count; }
    }

    public Path()
    {
        this.path = new List<Point3D>();
    }

    public void Add(Point3D point)
    {
        this.path.Add(point);
    }

    public void Remove(Point3D point)
    {
        this.path.Remove(point);
    }
    public override string ToString()
    {
        var output = new StringBuilder();

        foreach (var point in this.path)
        {
            output.AppendLine(string.Format("p1 : X:{0} Y:{1} Z:{2}", point.X, point.Y, point.Z));
        }

        return output.ToString();
    }
}