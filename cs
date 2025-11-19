import os

# The file where tasks will be saved. It will be created in the same directory 
# where you run the Python script.
TASK_FILE = "todo_list.txt"

def load_tasks():
    """Reads tasks from the file and returns them as a list."""
    try:
        # 'r' mode opens the file for reading
        with open(TASK_FILE, 'r') as file:
            # Read all lines and strip leading/trailing whitespace (like '\n')
            tasks = [line.strip() for line in file.readlines()]
        return tasks
    except FileNotFoundError:
        # If the file doesn't exist yet, return an empty list
        return []

def save_tasks(tasks):
    """Writes the current list of tasks to the file."""
    # 'w' mode opens the file for writing (and overwrites existing content)
    with open(TASK_FILE, 'w') as file:
        # Write each task on a new line
        for task in tasks:
            file.write(task + '\n')

def view_tasks(tasks):
    print("\n📝 Your To-Do List:")
    if not tasks:
        print("  (Empty! Add a new task.)")
    else:
        # Enumerate gives both the index (i) and the value (task)
        for i, task in enumerate(tasks):
            print(f"  {i + 1}. {task}")
    print("-" * 25)

def add_task(tasks):
    task = input("Enter the new task: ").strip()
    if task:
        tasks.append(task)
        print(f'✅ Task "{task}" added.')
        save_tasks(tasks)
    else:
        print("❌ Task cannot be empty.")

def delete_task(tasks):
    view_tasks(tasks)
    if not tasks:
        return

    try:
        # Get the task number (user input is 1-based, list index is 0-based)
        task_num = int(input("Enter the number of the task to delete: "))
        
        # Validate the input number
        if 1 <= task_num <= len(tasks):
            # Pop removes the item at the specified index (task_num - 1)
            deleted_task = tasks.pop(task_num - 1)
            print(f'🗑️ Task "{deleted_task}" deleted.')
            save_tasks(tasks)
        else:
            print("❌ Invalid task number.")
            
    except ValueError:
        print("❌ Please enter a valid number.")

def show_menu():
    print("\n📋 To-Do List Menu:")
    print("1. View Tasks")
    print("2. Add Task")
    print("3. Delete Task")
    print("4. Exit")
    choice = input("Choose an option: ")
    return choice

def main():
    # 1. Load existing tasks when the app starts
    tasks = load_tasks()

    while True:
        choice = show_menu()

        if choice == '1':
            view_tasks(tasks)
        elif choice == '2':
            add_task(tasks)
        elif choice == '3':
            delete_task(tasks)
        elif choice == '4':
            print("👋 Saving and exiting. Goodbye!")
            # Save is handled within add_task and delete_task, but this ensures a clean exit
            break
        else:
            print("❓ Invalid choice. Please select 1, 2, 3, or 4.")

# Standard Python entry point
if __name__ == "__main__":
    main()