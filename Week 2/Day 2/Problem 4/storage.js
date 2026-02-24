// ================== IN-MEMORY TASK ARRAY ==================
let tasks = [];

// ================== CALLBACK VERSION ==================

export const addTaskCallback = (task, callback) => {

    setTimeout(() => {
        tasks.push(task);
        callback(null, `Task "${task}" added successfully`);
    }, 1000);
};

export const deleteTaskCallback = (taskName, callback) => {

    setTimeout(() => {

        const index = tasks.indexOf(taskName);

        if (index === -1) {
            callback("Task not found", null);
        } else {
            tasks.splice(index, 1);
            callback(null, `Task "${taskName}" deleted`);
        }

    }, 1000);
};

export const listTasksCallback = (callback) => {

    setTimeout(() => {
        callback(null, [...tasks]);
    }, 1000);
};

// ================== PROMISE VERSION ==================

export const addTaskPromise = (task) => {

    return new Promise((resolve) => {

        setTimeout(() => {
            tasks.push(task);
            resolve(`Task "${task}" added successfully`);
        }, 1000);

    });
};

export const deleteTaskPromise = (taskName) => {

    return new Promise((resolve, reject) => {

        setTimeout(() => {

            const index = tasks.indexOf(taskName);

            if (index === -1) {
                reject("Task not found");
            } else {
                tasks.splice(index, 1);
                resolve(`Task "${taskName}" deleted`);
            }

        }, 1000);

    });
};

export const listTasksPromise = () => {

    return new Promise((resolve) => {

        setTimeout(() => {
            resolve([...tasks]);
        }, 1000);

    });
};

// ================== ASYNC/AWAIT VERSION ==================

export const addTaskAsync = async (task) => {

    return new Promise((resolve) => {

        setTimeout(() => {
            tasks.push(task);
            resolve(`Task "${task}" added successfully`);
        }, 1000);

    });
};

export const deleteTaskAsync = async (taskName) => {

    return new Promise((resolve, reject) => {

        setTimeout(() => {

            const index = tasks.indexOf(taskName);

            if (index === -1) {
                reject("Task not found");
            } else {
                tasks.splice(index, 1);
                resolve(`Task "${taskName}" deleted`);
            }

        }, 1000);

    });
};

export const listTasksAsync = async () => {

    return new Promise((resolve) => {

        setTimeout(() => {
            resolve([...tasks]);
        }, 1000);

    });
};