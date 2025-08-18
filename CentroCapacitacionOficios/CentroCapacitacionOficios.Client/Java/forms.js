function createFormModal(title, fields, onSubmit) {
    const modal = document.createElement('div');
    modal.className = 'modal';
    modal.style.display = 'block';
    
    let fieldsHtml = '';
    fields.forEach(field => {
        if (field.type === 'select') {
            fieldsHtml += `
                <div class="form-group">
                    <label for="${field.name}">${field.label}:</label>
                    <select id="${field.name}" name="${field.name}" required>
                        ${field.options.map(option => 
                            `<option value="${option.value}">${option.text}</option>`
                        ).join('')}
                    </select>
                </div>
            `;
        } else {
            fieldsHtml += `
                <div class="form-group">
                    <label for="${field.name}">${field.label}:</label>
                    <input type="${field.type || 'text'}" id="${field.name}" name="${field.name}" 
                           ${field.required ? 'required' : ''} ${field.placeholder ? `placeholder="${field.placeholder}"` : ''}>
                </div>
            `;
        }
    });
    
    modal.innerHTML = `
        <div class="modal-content">
            <div class="modal-header">
                <span class="close" onclick="closeFormModal()">&times;</span>
                <h2>${title}</h2>
            </div>
            <div class="modal-body">
                <form id="dynamicForm">
                    ${fieldsHtml}
                    <button type="submit" class="btn btn-primary" style="width: 100%;">Guardar</button>
                </form>
            </div>
        </div>
    `;
    
    document.body.appendChild(modal);
    
    modal.querySelector('#dynamicForm').addEventListener('submit', function(e) {
        e.preventDefault();
        const formData = new FormData(this);
        const data = {};
        for (let [key, value] of formData.entries()) {
            data[key] = value;
        }
        onSubmit(data);
        closeFormModal();
    });
    
    modal.onclick = function(event) {
        if (event.target === modal) {
            closeFormModal();
        }
    };
    
    window.currentFormModal = modal;
}

function closeFormModal() {
    if (window.currentFormModal) {
        window.currentFormModal.remove();
        window.currentFormModal = null;
    }
}

async function showAdvancedCourseForm() {
    return new Promise((resolve) => {
        const instructorOptions = currentData.instructors.map(instructor => ({
            value: instructor.id,
            text: instructor.name
        }));
        
        if (instructorOptions.length === 0) {
            instructorOptions.push({ value: '', text: 'No hay instructores disponibles' });
        }
        
        const fields = [
            { name: 'name', label: 'Nombre del Curso', required: true },
            { name: 'description', label: 'Descripción', required: true },
            { name: 'durationHours', label: 'Duración (horas)', type: 'number', required: true },
            { 
                name: 'instructorId', 
                label: 'Instructor', 
                type: 'select', 
                options: instructorOptions,
                required: true 
            }
        ];
        
        createFormModal('Agregar Nuevo Curso', fields, (data) => {
            resolve({
                name: data.name,
                description: data.description,
                durationHours: parseInt(data.durationHours),
                instructorId: parseInt(data.instructorId)
            });
        });
    });
}

async function showAdvancedVideoForm() {
    return new Promise((resolve) => {
        const courseOptions = currentData.courses.map(course => ({
            value: course.id,
            text: course.name
        }));
        
        if (courseOptions.length === 0) {
            courseOptions.push({ value: '', text: 'No hay cursos disponibles' });
        }
        
        const fields = [
            { name: 'title', label: 'Título del Video', required: true },
            { name: 'videoUrl', label: 'URL del Video', type: 'url', required: true },
            { 
                name: 'courseId', 
                label: 'Curso', 
                type: 'select', 
                options: courseOptions,
                required: true 
            }
        ];
        
        createFormModal('Agregar Nuevo Video', fields, (data) => {
            resolve({
                title: data.title,
                videoUrl: data.videoUrl,
                courseId: parseInt(data.courseId)
            });
        });
    });
}

async function showAdvancedCertificateForm() {
    return new Promise((resolve) => {
        const userOptions = currentData.users.map(user => ({
            value: user.id,
            text: user.name
        }));
        
        const courseOptions = currentData.courses.map(course => ({
            value: course.id,
            text: course.name
        }));
        
        if (userOptions.length === 0) {
            alert('No hay usuarios registrados');
            resolve(null);
            return;
        }
        
        if (courseOptions.length === 0) {
            alert('No hay cursos disponibles');
            resolve(null);
            return;
        }
        
        const fields = [
            { 
                name: 'userId', 
                label: 'Estudiante', 
                type: 'select', 
                options: userOptions,
                required: true 
            },
            { 
                name: 'courseId', 
                label: 'Curso Completado', 
                type: 'select', 
                options: courseOptions,
                required: true 
            }
        ];
        
        createFormModal('Emitir Nuevo Certificado', fields, (data) => {
            resolve({
                userId: parseInt(data.userId),
                courseId: parseInt(data.courseId)
            });
        });
    });
}

async function editUserForm(user) {
    return new Promise((resolve) => {
        const fields = [
            { name: 'name', label: 'Nombre', required: true },
            { name: 'email', label: 'Email', type: 'email', required: true }
        ];
        
        createFormModal('Editar Usuario', fields, (data) => {
            resolve({
                id: user.id,
                name: data.name,
                email: data.email,
                registrationDate: user.registrationDate
            });
        });
        
        document.getElementById('name').value = user.name;
        document.getElementById('email').value = user.email;
    });
}

async function editCourseForm(course) {
    return new Promise((resolve) => {
        const instructorOptions = currentData.instructors.map(instructor => ({
            value: instructor.id,
            text: instructor.name
        }));
        
        const fields = [
            { name: 'name', label: 'Nombre del Curso', required: true },
            { name: 'description', label: 'Descripción', required: true },
            { name: 'durationHours', label: 'Duración (horas)', type: 'number', required: true },
            { 
                name: 'instructorId', 
                label: 'Instructor', 
                type: 'select', 
                options: instructorOptions,
                required: true 
            }
        ];
        
        createFormModal('Editar Curso', fields, (data) => {
            resolve({
                id: course.id,
                name: data.name,
                description: data.description,
                durationHours: parseInt(data.durationHours),
                instructorId: parseInt(data.instructorId)
            });
        });
        
        setTimeout(() => {
            document.getElementById('name').value = course.name;
            document.getElementById('description').value = course.description;
            document.getElementById('durationHours').value = course.durationHours;
            document.getElementById('instructorId').value = course.instructorId;
        }, 100);
    });
}

async function editInstructorForm(instructor) {
    return new Promise((resolve) => {
        const fields = [
            { name: 'name', label: 'Nombre', required: true },
            { name: 'specialty', label: 'Especialidad', required: true },
            { name: 'email', label: 'Email', type: 'email', required: true }
        ];
        
        createFormModal('Editar Instructor', fields, (data) => {
            resolve({
                id: instructor.id,
                name: data.name,
                specialty: data.specialty,
                email: data.email
            });
        });
        
        setTimeout(() => {
            document.getElementById('name').value = instructor.name;
            document.getElementById('specialty').value = instructor.specialty;
            document.getElementById('email').value = instructor.email;
        }, 100);
    });
}

async function editVideoForm(video) {
    return new Promise((resolve) => {
        const courseOptions = currentData.courses.map(course => ({
            value: course.id,
            text: course.name
        }));
        
        const fields = [
            { name: 'title', label: 'Título del Video', required: true },
            { name: 'videoUrl', label: 'URL del Video', type: 'url', required: true },
            { 
                name: 'courseId', 
                label: 'Curso', 
                type: 'select', 
                options: courseOptions,
                required: true 
            }
        ];
        
        createFormModal('Editar Video', fields, (data) => {
            resolve({
                id: video.id,
                title: data.title,
                videoUrl: data.videoUrl,
                courseId: parseInt(data.courseId)
            });
        });
        
        setTimeout(() => {
            document.getElementById('title').value = video.title;
            document.getElementById('videoUrl').value = video.videoUrl;
            document.getElementById('courseId').value = video.courseId;
        }, 100);
    });
}