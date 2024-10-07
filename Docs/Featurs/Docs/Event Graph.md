# About
The *Event Graph* Shows a time line of events using a bar. Each Bar in the graph shows a **Event**. **Events** can be anything. It can show if a machine is running or being setup or event if it is not making parts.
![[Pasted image 20241003102807.png]]

# Events
An **Event** can be almost anything. An **Event** is the status of the machine that can be logged by time. A Good Event to be logged would *machine uptime* *(in the green)*. The *Red* status can be setup, And the blue red cand be test run. 

Each event must have a time, description, name, and a color. This Event must be built and added to the **EventList** in the Event Graph. The user must update this event until the event changes and you must update that Event. This Graph uses time in seconds. You can change that time by changing **MaxTime** in the *Event Graph*.

When you hover with your mouse over an **Event** it will display its name and description. The **Color** must be unique to the **Event**, The **Color** is a visual way to categorize the **Event Type**.