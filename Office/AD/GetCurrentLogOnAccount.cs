public string GetCurrentLogOnAccount()
{
    return WindowsIdentity.GetCurrent().Name;
    // return "XD-AD\\01118-dw";
    //return "01118-dw";
    //return "XD-AD\\03173";
}
