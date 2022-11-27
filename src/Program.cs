/*
    Microsoft IoT Raspberry pi PWM 呼吸燈 sample
    Raspberry pi PWM 是軟體模擬﹐CPU 會額外負擔處理﹐以呼吸燈為例﹐可以看的出整個變化並不是很滑順
    reference:https://github.com/dotnet/iot/blob/main/src/devices/SoftPwm/samples/Program.cs
*/
using System;
using System.Device.Pwm.Drivers;
using System.Threading;

Console.WriteLine("Software PWM Breathe Led Start.");
int pin = 27;  //GPIO 27 => BCM 27 = 接腳 36
using SoftwarePwmChannel pwmChannel = new(pin, 400, 0);
pwmChannel.Start();

while (true)
{
  Console.WriteLine("逐漸變亮");
  for (double fill = 0.0; fill <= 1.0; fill += 0.01)
  {
    pwmChannel.DutyCycle = fill;
    Thread.Sleep(10);
  }
  Thread.Sleep(1000);
  Console.WriteLine("逐漸變暗");
  for (double fill = 1.0; fill >= 0.0; fill -= 0.01)
  {
    pwmChannel.DutyCycle = fill;
    Thread.Sleep(10);
  }
}
