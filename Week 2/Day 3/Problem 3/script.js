// ================= SELECT ELEMENTS =================
const taskInput = document.getElementById("taskInput");
const addBtn = document.getElementById("addBtn");
const taskList = document.getElementById("taskList");

// ================= ADD TASK FUNCTION =================
const addTask = () => {

    const taskText = taskInput.value.trim();

    if (taskText === "") return;

    const li = document.createElement("li");

    li.innerHTML = `
        <span class="task-text">${taskText}</span>
        <button class="delete-btn">Delete</button>
    `;

    taskList.appendChild(li);

    taskInput.value = "";
};

// ================= EVENT LISTENER FOR ADD =================
addBtn.addEventListener("click", addTask);


// ================= EVENT DELEGATION =================
// Instead of adding listeners to every delete button,
// we attach ONE listener to the parent (ul)

taskList.addEventListener("click", (event) => {

    // DELETE TASK
    if (event.target.classList.contains("delete-btn")) {
        event.target.parentElement.remove();
    }

    // MARK COMPLETE
    if (event.target.classList.contains("task-text")) {
        event.target.classList.toggle("completed");
    }

});