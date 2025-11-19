import os


TASK_FILE = "todo_list.txt"

def load_tasks():
    
    try:
      
        with open(TASK_FILE, 'r') as file:
          
            tasks = [line.strip() for line in file.readlines()]
        return tasks
    except FileNotFoundError:
        
        return []

def save_tasks(tasks):
    
    with open(TASK_FILE, 'w') as file:
        
        for task in tasks:
            file.write(task + '\n')

def view_tasks(tasks):
    print("\n📝 Your To-Do List:")
    if not tasks:
        print("  (Empty! Add a new task.)")
    else:
     
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
        
        task_num = int(input("Enter the number of the task to delete: "))
        
     
        if 1 <= task_num <= len(tasks):
           
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
           
            break
        else:
            print("❓ Invalid choice. Please select 1, 2, 3, or 4.")


if __name__ == "__main__":
    main()