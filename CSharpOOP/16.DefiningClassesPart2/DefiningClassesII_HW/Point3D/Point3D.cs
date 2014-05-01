﻿using System;

struct Point3D
{
    private static readonly Point3D zeroPoint = new Point3D(0, 0, 0);

    private double x;
    private double y;
    private double z;
 
    public double X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    public double Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    public double Z
    {
        get { return this.z; }
        set {this.z = value; }
    }

    public static Point3D ZeroPoint
    {
        get { return zeroPoint; }   
    }
    
    public Point3D(double x, double y, double z)
        :this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }
    
    public override string ToString()
    {
        return string.Format("X:{0} Y:{1} Z:{2}", this.X, this.Y, this.Z);
    }
}

