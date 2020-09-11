using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Colour
    {
        public UInt32 colour;

        // Default colour constructor
        public Colour()
        {
            colour = 0;
        }

        // colour constructor
        public Colour(byte red, byte green, byte blue, byte alpha)
        {
            SetRed(red);
            SetGreen(green);
            SetBlue(blue);
            SetAlpha(alpha);
        }
        // Get the red portion of the value
        public byte GetRed()
        {
            return (byte)((colour & 0xff000000) >> 24);
        }
        // set the red portion of the value
        public void SetRed(byte red)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)red << 24;
        }

        // get the Green portion of the value
        public byte GetGreen()
        {
            return (byte)((colour & 0x00ff0000) >> 16);

        }
        // set the green portion of the value
        public void SetGreen(byte green)
        {
            colour = colour & 0xff00ffff;
            colour |= (UInt32)green << 16;
        }

        // Get the Blue seciton of the value
        public byte GetBlue()
        {
            return (byte)((colour & 0x0000ff00) >> 8);
        }

        // Set the blue section  for  value
        public void SetBlue(byte blue)
        {
            colour = colour & 0xffff00ff;
            colour |= (UInt32)blue << 8;
        }

        // Get the Appha section of the value.
        public byte GetAlpha()
        {
            return (byte)((colour & 0x000000ff) >> 0);
        }

        // Set the Alpha value for the value
        public void SetAlpha(byte alpha)
        {
            colour = colour & 0xffffff00;
            colour |= (UInt32)alpha << 0;
        }

        // shifts the current Red value into the Green position
        public void ShiftRedToGreen()
        {
            UInt32  newGreen = (colour & 0xFF000000) >> 8;
            UInt32 newColour = (colour & 0x0000FFFF);
            colour = newColour + newGreen;

        }

    }
}
