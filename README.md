# Mvvm.Example

## Project

### UI

#### WPF

- **MainPage**  
<img width="600" src="https://github.com/user-attachments/assets/c206c5b1-c39d-43b0-b77c-22260bf8bca8" />

- **CounterPage**  
<img width="600" src="https://github.com/user-attachments/assets/844d09b3-e15d-47ff-9a8b-efe8ead47c15" />
<img width="600" src="https://github.com/user-attachments/assets/2ce0fa89-1cf4-4b32-8eca-f1ef746b601c" />

#### Avalonia

- **MainPage**  
<img width="600" src="https://github.com/user-attachments/assets/77db80ae-fa02-478d-8110-78d7ba11de03" />

- **CounterPage**  
<img width="600" src="https://github.com/user-attachments/assets/cb7e5497-b360-42c7-9b21-e096136e1fe6" />
<img width="600" src="https://github.com/user-attachments/assets/00884025-d40f-4178-87a2-dc861c0bdb5b" />

### Mvvm.Example.Abstractions  
A project that contains abstract code commonly used across all other projects.

### Mvvm.Example.ViewModels  
A project that contains ViewModel classes which interact with Views through data binding.

### Mvvm.Example.Models  
A project that contains model classes related to data.

### Mvvm.Example.ViewModels.Tests  
A project that tests the `Mvvm.Example.ViewModels` project.  
- It tests the `CounterPageViewModel` by executing the `IncrementCommand` and verifying that the `Counter` property changes to 1.
