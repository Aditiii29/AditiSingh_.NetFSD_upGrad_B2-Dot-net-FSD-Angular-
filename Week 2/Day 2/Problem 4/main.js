// ================ Callback Demo =================
import {
    addTaskCallback,
    deleteTaskCallback,
    listTasksCallback
} from "./storage.js";

addTaskCallback("Study JS", (err, msg) => {

    if (err) return console.log(err);
    console.log(msg);

    listTasksCallback((err, data) => {
        console.log(`Current Tasks: ${data}`);
    });
});

// ================ Promise Demo =================
import {
    addTaskPromise,
    listTasksPromise
} from "./storage.js";

addTaskPromise("Learn Promises")
    .then(msg => {
        console.log(msg);
        return listTasksPromise();
    })
    .then(tasks => {
        console.log(`Tasks: ${tasks}`);
    })
    .catch(err => console.log(err));

// ================ Async/Await Demo =================
import {
    addTaskAsync,
    deleteTaskAsync,
    listTasksAsync
} from "./storage.js";

const runTaskManager = async () => {

    try {

        console.log(await addTaskAsync("Build Project"));
        console.log(await addTaskAsync("Prepare Interview"));

        const tasks = await listTasksAsync();
        console.log(`Tasks: ${tasks}`);

        console.log(await deleteTaskAsync("Build Project"));

        const updated = await listTasksAsync();
        console.log(`Updated Tasks: ${updated}`);

    } catch (error) {
        console.log(`Error: ${error}`);
    }
};

runTaskManager();