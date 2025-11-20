using System.Globalization;
using System.Windows.Data;

namespace ZullaWpf.Converters;

public class BoolToSaveUpdateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isEditMode)
        {
            return isEditMode ? "Update" : "Save";
        }
        return "Save";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
