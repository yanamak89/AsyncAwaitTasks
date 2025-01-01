# Homework 15: Working with Synchronization Context and `async`/`await`

## Task Description
This homework focuses on understanding and working with the synchronization context in C#. The goal is to deepen your knowledge of asynchronous programming, synchronization contexts, and how to handle exceptions in asynchronous methods.

---

## Tasks

### Task 1
Study the key concepts and structures covered during the lesson.

---

### Task 2
1. **Template**: Create a program using the Console Application template.
2. **Synchronization Context**:
   - Implement a custom synchronization context by overriding the `Post` method.
   - The `Post` method should execute the provided delegate in the context of a new thread (`Thread`).
   - Assign a name to the thread created by the `Post` method.
3. **Main Method**:
   - Set the custom synchronization context at the start of the `Main` method.
4. **Asynchronous Method**:
   - Implement an asynchronous method that calculates the factorial of a number using a loop.
   - Use the `await` operator to wait for the task to complete.
   - Output to the console:
     - `ManagedThreadId` (thread ID),
     - `Name` (thread name),
     - `IsThreadPoolThread` (whether the thread is from the thread pool) both before and after the `await` operator.

---

### Task 3
1. **Template**: Use the program created in Task 2.
2. **Requirement**:
   - Without removing or changing the synchronization context, ensure that the continuation after the `await` operator is executed in the context of a thread from the thread pool.
3. **Implementation**:
   - Use `ConfigureAwait(false)` after the `await` operator.

---

### Task 4
1. **Template**: Create a program using the Console Application template.
2. **Synchronization Context**:
   - Implement a synchronization context capable of handling exceptions that occur in asynchronous methods with a `void` return type.
3. **Exception Handling**:
   - Verify whether exceptions in such methods are handled by your synchronization context.
   - Demonstrate exception handling within the synchronization context.
4. **Conclusion**:
   - Provide insights regarding the use of asynchronous methods with a `void` return type.

---

## Expected Results
1. Implement each task, demonstrating a clear understanding of how synchronization contexts work.
2. Ensure each program correctly manages threads and handles exceptions.
3. Formulate conclusions about the specific use cases for synchronization contexts and asynchronous methods.

---

## Conclusions
- **Synchronization Context**: Allows control over the threads in which asynchronous operations execute.
- **`async void` Methods**:
  - Should only be used for event handlers.
  - Exceptions in these methods are difficult to catch without a custom synchronization context.
- **`ConfigureAwait(false)`**: 
  - It avoids returning to the original synchronization context, reducing overhead in asynchronous operations.

---

## Instructions for Execution
1. Create separate projects for each task.
2. Implement the logic according to the requirements.
3. Run the programs and verify their output matches the expected behavior.
4. Add comments and conclusions to each completed task.
