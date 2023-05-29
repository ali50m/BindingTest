InvalidOperationException: Cannot freeze this Storyboard timeline tree for use across threads.

![image](https://github.com/ali50m/BindingTest/assets/9393831/2b6184c0-955d-4da7-9114-cc45f327a4aa)

```csharp
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*" />
        <ColumnDefinition Width="*" />
    </Grid.ColumnDefinitions>
    <Viewbox Grid.Column="0" Width="100">
        <CheckBox x:Name="CheckBox" />
    </Viewbox>
    <bindingTest:MyBorder
        x:Name="MyBorder"
        Grid.Column="1"
        Background="Transparent">
        <bindingTest:MyBorder.Triggers>
            <EventTrigger RoutedEvent="bindingTest:MyBorder.Loaded">
                <BeginStoryboard>
                    <Storyboard>
                        <ColorAnimation
                            Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)"
                            From="LightBlue"
                            To="{Binding ElementName=MyBorder, Path=OnBrush}"
                            Duration="0:0:1" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </bindingTest:MyBorder.Triggers>
        <bindingTest:MyBorder.Style>
            <Style TargetType="{x:Type bindingTest:MyBorder}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding ElementName=CheckBox, Path=IsChecked}" Value="True">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <ColorAnimation
                                        Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)"
                                        From="LightBlue"
                                        To="{Binding ElementName=MyBorder, Path=OnBrush}"
                                        Duration="0:0:1" />
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.EnterActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </bindingTest:MyBorder.Style>
    </bindingTest:MyBorder>
</Grid>
```