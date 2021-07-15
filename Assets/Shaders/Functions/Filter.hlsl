void Filter_float(in float Input, in float Threshold, out float Out)
{
    if(Input.x < Threshold.x)
    {
        Out = 0;
    }
    else
        Out = Input;
}