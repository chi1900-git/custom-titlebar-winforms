# Custom Title Bar WinForms

A customizable title bar control for WinForms applications with adjustable height, font, colors, and button styling.

## Features

✅ **Adjustable Title Bar Height** - Set any height from 30 to 80 pixels
✅ **Font Customization** - Change font family, size, and style
✅ **Color Properties**:
   - Title bar background color
   - Title text color
   - Button hover color
   - Close button hover/press colors

✅ **Window Controls**
   - Minimize button
   - Maximize/Restore button
   - Close button

✅ **User Interactions**
   - Drag window by title bar
   - Double-click to maximize/restore
   - Hover effects on buttons
   - Press/click animations

## Usage

### Create a Custom Form

```csharp
public class MyForm : CustomForm
{
    public MyForm()
    {
        this.Text = "My Application";
        this.Size = new Size(800, 600);
        
        // Customize title bar
        TitleBar.TitleBarHeight = 50;
        TitleBar.TitleBarBackColor = Color.FromArgb(33, 37, 41);
        TitleBar.TitleFontColor = Color.White;
        TitleBar.TitleFont = new Font("Segoe UI", 13, FontStyle.Bold);
    }
}
```

### Custom Title Bar Properties

- `TitleBarHeight` - Height of the title bar (30-80 pixels)
- `TitleBarBackColor` - Background color of title bar
- `TitleFontColor` - Color of title text
- `TitleFont` - Font family, size, and style
- `ButtonHoverColor` - Hover color for minimize/maximize buttons
- `ButtonPressColor` - Press color for buttons
- `CloseButtonHoverColor` - Hover color for close button
- `CloseButtonPressColor` - Press color for close button

## Technical Details

- **Framework**: .NET Framework 4.8
- **Language**: C#
- **Platform**: Windows Forms
- **Border Style**: FormBorderStyle.None (custom rendering)

## Files

- `CustomTitleBar.cs` - The title bar control
- `CustomForm.cs` - Base form class with custom title bar
- `MainForm.cs` - Demo application
- `Program.cs` - Application entry point

## Demo Application

The demo application shows how to customize all properties in real-time with:
- Text input for title
- Numeric controls for height and font size
- Color pickers for all colors
- Reset button to restore defaults

## How It Works

1. **CustomForm** removes the standard Windows title bar (FormBorderStyle.None)
2. **CustomTitleBar** creates a custom panel that acts as the title bar
3. Buttons for minimize, maximize, and close are custom-rendered
4. Mouse events handle dragging and double-click maximize
5. All colors and fonts are customizable through properties

## License

Free to use and modify for your projects.
