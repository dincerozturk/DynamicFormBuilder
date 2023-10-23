namespace DynamicFormBuilder.Domain.Enums
{
    public enum ElementType
    {
        input,
        label,
        select,
        textarea,
        button,
        fieldset,
        legend,
        datalist,
        output,
        option,
        optgroup,
    }

    public enum ElementInputType
    {
        button,
        checkbox,
        color,
        datetimelocal,
        email,
        file,
        hidden,
        image,
        month,
        number,
        password,
        radio,
        range,
        reset,
        search,
        submit,
        tel,
        text,
        time,
        url,
        week,
    }

    /// <summary>
    /// InputElement değer tipleri
    /// </summary>
    public enum ValueType
    {
        Number,
        Text,
        ListInt,
        ListText,
        Datetime,
        Boolean,
    }
}