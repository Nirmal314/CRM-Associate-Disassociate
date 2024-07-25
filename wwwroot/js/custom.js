//? utility functions

function getSelectValues(select) {
    var result = [];
    var options = select && select.options;
    var opt;

    for (var i = 0, iLen = options.length; i < iLen; i++) {
        opt = options[i];

        if (opt.selected) {
            result.push(opt.value || opt.text);
        }
    }
    return result;
}

function findValueByKey(data, key) {
    for (let i = 0; i < data.length; i++) {
        if (data[i].key === key) {
            return data[i].value;
        }
    }
    return null;
}

//? handlers

const getTasks = (pid) => {
    AjaxCall(`/Task/GetTask`, "GET", { project_id: pid }, null,

        (response) => {
            $("#tasks").html(response)
            // $.validator.unobtrusive.parse($("#customer-form"));
            $("#taskModal").modal("show")
        },

        (error) => console.log(error)
    );
}

const disassociate = (tid, pid) => {
    AjaxCall(`/ProjectTask/Disassociate`, "GET", { task_id: tid, project_id: pid }, null,

        (response) => {
            if (response.success) {
                $("#taskModal").modal("hide")
                alert("Record disassociated.")
            } else {
                alert("Error: ", response.error)
            }
            console.log(response)
        },

        (error) => console.log(error)
    );
}


const getTaskList = (pid) => {

    const prepareSelectElement = (tasks) => {
        const select = document.createElement('select');
        select.className = 'form-select';
        select.size = 10;
        select.multiple = true;
        select.id = "select-tasks"

        tasks.forEach(task => {
            let _task = task.attributes;
            const _pid = findValueByKey(_task, "cr267_projectv2")

            const opt = document.createElement('option');
            opt.textContent = findValueByKey(_task, "cr267_taskname");
            opt.value = findValueByKey(_task, "cr267_projecttaskid")

            if (_pid && _pid.id === pid) {
                opt.selected = true;
            } else {
                opt.selected = false;
            }

            select.appendChild(opt);
        })

        $("#tasks").html(select)
        $("#tasks").append(`
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary disabled"  id="save-tasks">Save changes</button>
                    </div>
                `)
    }

    const associate = (selectedTasks, pid) => {
        AjaxCall(`/ProjectTask/Associate`, "POST", { selectedTasks, project_id: pid }, null,

            (response) => {
                if (response.success) {
                    $("#taskModal").modal("hide")
                    alert("Records associated.")
                } else {
                    alert("Error: ", response.error)
                }
                console.log(response)
            },

            (error) => console.log(error)
        );
    }

    AjaxCall(`/Task/GetAllTasks`, "GET", null, null,

        (response) => {
            if (response.success) {
                let tasks = response.tasks.entities;

                prepareSelectElement(tasks)

                $("#taskModal").modal("show")

                document.getElementById("select-tasks").onchange = () => {
                    document.getElementById("save-tasks").classList.remove("disabled");
                }

                document.getElementById("save-tasks").onclick = () => {
                    const select = document.getElementById("select-tasks")
                    const selectedTasks = getSelectValues(select)

                    //! ajax call
                    associate(selectedTasks, pid)
                }
            } else {
                alert("Error: ", response.error)
            }
            console.log(response)
        },

        (error) => console.log(error)
    );
}