let currentUser = null;
let currentData = {
    courses: [],
    instructors: [],
    users: [],
    videos: [],
    certificates: []
};

document.addEventListener('DOMContentLoaded', function() {
    initializeApp();
});

async function initializeApp() {
    try {
        setupEventListeners();
        setupAnimations();
        
        // Try to load data, but don't fail if API is not available
        try {
            await loadAllData();
            updateStatistics();
        } catch (apiError) {
            console.log('API not available, using offline mode');
            loadSampleData();
            hideLoadingIndicators();
        }
    } catch (error) {
        console.error('Error initializing app:', error);
        showNotification('Error al cargar la aplicación', 'error');
        hideLoadingIndicators();
    }
}

async function loadAllData() {
    try {
        currentData.courses = await apiService.getAllCourses();
        currentData.instructors = await apiService.getAllInstructors();
        currentData.users = await apiService.getAllUsers();
        currentData.videos = await apiService.getAllVideos();
        currentData.certificates = await apiService.getAllCertificates();
        
        renderAllTables();
        renderCoursesGrid();
        renderInstructorsGrid();
        hideLoadingIndicators();
    } catch (error) {
        console.error('Error loading data:', error);
        showNotification('Error al cargar los datos', 'error');
        throw error;
    }
}

function loadSampleData() {
    currentData = {
        courses: [
            { id: 1, name: 'Electricidad Básica', description: 'Curso básico de electricidad', durationHours: 40, instructorId: 1 },
            { id: 2, name: 'Plomería Avanzada', description: 'Curso avanzado de plomería', durationHours: 35, instructorId: 2 },
            { id: 3, name: 'Cocina Profesional', description: 'Curso de cocina profesional', durationHours: 50, instructorId: 3 }
        ],
        instructors: [
            { id: 1, name: 'Juan Pérez', specialty: 'Electricidad', email: 'juan@email.com' },
            { id: 2, name: 'María López', specialty: 'Plomería', email: 'maria@email.com' },
            { id: 3, name: 'Carlos Ruiz', specialty: 'Cocina', email: 'carlos@email.com' }
        ],
        users: [
            { id: 1, name: 'Admin', email: 'admin@centro.com', registrationDate: '2025-01-01' },
            { id: 2, name: 'Ana García', email: 'ana@email.com', registrationDate: '2025-01-15' },
            { id: 3, name: 'Luis Martín', email: 'luis@email.com', registrationDate: '2025-01-20' }
        ],
        videos: [
            { id: 1, title: 'Introducción a la Electricidad', videoUrl: 'https://example.com/video1', courseId: 1 },
            { id: 2, title: 'Instalación de Tuberías', videoUrl: 'https://example.com/video2', courseId: 2 },
            { id: 3, title: 'Técnicas de Cocción', videoUrl: 'https://example.com/video3', courseId: 3 }
        ],
        certificates: [
            { id: 1, userId: 2, courseId: 1, issuedDate: '2025-01-15' },
            { id: 2, userId: 3, courseId: 2, issuedDate: '2025-01-20' }
        ]
    };
    
    renderAllTables();
    renderCoursesGrid();
    renderInstructorsGrid();
    updateStatistics();
}

function renderCoursesGrid() {
    const coursesGrid = document.getElementById('coursesGrid');
    if (!coursesGrid) return;

    coursesGrid.innerHTML = '';
    
    currentData.courses.forEach(course => {
        const instructor = currentData.instructors.find(i => i.id === course.instructorId);
        const instructorName = instructor ? instructor.name : 'Sin instructor';
        
        coursesGrid.innerHTML += `
            <div class="course-card">
                <div class="course-icon">📚</div>
                <h3>${course.name}</h3>
                <p>${course.description}</p>
                <p><strong>Instructor:</strong> ${instructorName}</p>
                <p><strong>Duración:</strong> ${course.durationHours} horas</p>
                <a href="#" class="btn btn-primary" onclick="viewCourseDetails(${course.id})">Ver Detalles</a>
            </div>
        `;
    });
}

function renderAllTables() {
    renderUsersTable();
    renderCoursesTable();
    renderInstructorsTable();
    renderVideosTable();
    renderCertificatesTable();
}

function renderUsersTable() {
    const tbody = document.getElementById('usersTableBody');
    if (!tbody) return;

    tbody.innerHTML = '';
    currentData.users.forEach(user => {
        const registrationDate = user.registrationDate ? 
            new Date(user.registrationDate).toLocaleDateString('es-ES') : 
            'No especificada';
            
        tbody.innerHTML += `
            <tr>
                <td>${user.id}</td>
                <td>${user.name}</td>
                <td>${user.email}</td>
                <td>${registrationDate}</td>
                <td class="action-buttons">
                    <button class="btn btn-small btn-edit" onclick="editUser(${user.id})">Editar</button>
                    <button class="btn btn-small btn-delete" onclick="deleteUser(${user.id})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}

function renderCoursesTable() {
    const tbody = document.getElementById('coursesTableBody');
    if (!tbody) return;

    tbody.innerHTML = '';
    currentData.courses.forEach(course => {
        const instructor = currentData.instructors.find(i => i.id === course.instructorId);
        const instructorName = instructor ? instructor.name : 'Sin instructor';
        
        tbody.innerHTML += `
            <tr>
                <td>${course.id}</td>
                <td>${course.name}</td>
                <td>${instructorName}</td>
                <td>${course.durationHours} horas</td>
                <td class="action-buttons">
                    <button class="btn btn-small btn-edit" onclick="editCourse(${course.id})">Editar</button>
                    <button class="btn btn-small btn-delete" onclick="deleteCourse(${course.id})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}

function renderInstructorsTable() {
    const tbody = document.getElementById('instructorsTableBody');
    if (!tbody) return;

    tbody.innerHTML = '';
    currentData.instructors.forEach(instructor => {
        tbody.innerHTML += `
            <tr>
                <td>${instructor.id}</td>
                <td>${instructor.name}</td>
                <td>${instructor.specialty}</td>
                <td>${instructor.email}</td>
                <td class="action-buttons">
                    <button class="btn btn-small btn-edit" onclick="editInstructor(${instructor.id})">Editar</button>
                    <button class="btn btn-small btn-delete" onclick="deleteInstructor(${instructor.id})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}

function renderVideosTable() {
    const tbody = document.getElementById('videosTableBody');
    if (!tbody) return;

    tbody.innerHTML = '';
    currentData.videos.forEach(video => {
        const course = currentData.courses.find(c => c.id === video.courseId);
        const courseName = course ? course.name : 'Sin curso';
        
        tbody.innerHTML += `
            <tr>
                <td>${video.id}</td>
                <td>${video.title}</td>
                <td>${courseName}</td>
                <td><a href="${video.videoUrl}" target="_blank">Ver Video</a></td>
                <td class="action-buttons">
                    <button class="btn btn-small btn-edit" onclick="editVideo(${video.id})">Editar</button>
                    <button class="btn btn-small btn-delete" onclick="deleteVideo(${video.id})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}

function renderCertificatesTable() {
    const tbody = document.getElementById('certificatesTableBody');
    if (!tbody) return;

    tbody.innerHTML = '';
    currentData.certificates.forEach(certificate => {
        const user = currentData.users.find(u => u.id === certificate.userId);
        const course = currentData.courses.find(c => c.id === certificate.courseId);
        const userName = user ? user.name : 'Usuario no encontrado';
        const courseName = course ? course.name : 'Curso no encontrado';
        
        tbody.innerHTML += `
            <tr>
                <td>${certificate.id}</td>
                <td>${userName}</td>
                <td>${courseName}</td>
                <td>${new Date(certificate.issuedDate).toLocaleDateString()}</td>
                <td class="action-buttons">
                    <button class="btn btn-small btn-primary" onclick="viewCertificate(${certificate.id})">Ver</button>
                    <button class="btn btn-small btn-delete" onclick="deleteCertificate(${certificate.id})">Eliminar</button>
                </td>
            </tr>
        `;
    });
}

function setupEventListeners() {
    document.getElementById('loginForm').addEventListener('submit', handleLogin);
    document.getElementById('registerForm').addEventListener('submit', handleRegister);
}

async function handleLogin(e) {
    e.preventDefault();
    
    const email = document.getElementById('loginEmail').value;
    const password = document.getElementById('loginPassword').value;
    const userType = document.getElementById('userType').value;
    
    // Validación básica offline para admin
    if (email === 'admin@centro.com' && password === 'admin123' && userType === 'admin') {
        loginUser('Admin', 'admin');
        closeLoginModal();
        return;
    }
    
    // Intentar autenticación con API
    try {
        const users = await apiService.getAllUsers();
        const user = users.find(u => u.email === email);
        
        if (user) {
            loginUser(user.name, userType);
            closeLoginModal();
        } else {
            showNotification('Credenciales incorrectas', 'error');
        }
    } catch (error) {
        // Fallback para modo offline
        if (email && password) {
            loginUser(email.split('@')[0], userType);
            closeLoginModal();
            showNotification('Modo offline - sesión temporal', 'success');
        } else {
            showNotification('Ingrese email y contraseña', 'error');
        }
    }
}

async function handleRegister(e) {
    e.preventDefault();
    
    const name = document.getElementById('registerName').value;
    const email = document.getElementById('registerEmail').value;
    const password = document.getElementById('registerPassword').value;
    
    try {
        await apiService.createUser({
            name: name,
            email: email,
            password: password,
            registrationDate: new Date().toISOString()
        });
        
        showNotification('Registro exitoso. Por favor inicie sesión.', 'success');
        closeRegisterModal();
        document.getElementById('registerForm').reset();
        await loadAllData();
    } catch (error) {
        showNotification('Error en el registro', 'error');
    }
}

async function editUser(id) {
    const user = currentData.users.find(u => u.id === id);
    if (!user) return;

    try {
        const formData = await editUserForm(user);
        if (formData) {
            await apiService.updateUser(formData);
            showNotification('Usuario actualizado exitosamente', 'success');
            await loadAllData();
            updateStatistics();
        }
    } catch (error) {
        showNotification('Error al actualizar usuario', 'error');
    }
}

async function deleteUser(id) {
    if (confirm('¿Está seguro de eliminar este usuario?')) {
        try {
            await apiService.deleteUser(id);
            showNotification('Usuario eliminado exitosamente', 'success');
            await loadAllData();
        } catch (error) {
            showNotification('Error al eliminar usuario', 'error');
        }
    }
}

async function editCourse(id) {
    const course = currentData.courses.find(c => c.id === id);
    if (!course) return;

    try {
        const formData = await editCourseForm(course);
        if (formData) {
            await apiService.updateCourse(formData);
            showNotification('Curso actualizado exitosamente', 'success');
            await loadAllData();
            updateStatistics();
        }
    } catch (error) {
        showNotification('Error al actualizar curso', 'error');
    }
}

async function deleteCourse(id) {
    if (confirm('¿Está seguro de eliminar este curso?')) {
        try {
            await apiService.deleteCourse(id);
            showNotification('Curso eliminado exitosamente', 'success');
            await loadAllData();
        } catch (error) {
            showNotification('Error al eliminar curso', 'error');
        }
    }
}

async function editInstructor(id) {
    const instructor = currentData.instructors.find(i => i.id === id);
    if (!instructor) return;

    try {
        const formData = await editInstructorForm(instructor);
        if (formData) {
            await apiService.updateInstructor(formData);
            showNotification('Instructor actualizado exitosamente', 'success');
            await loadAllData();
            updateStatistics();
        }
    } catch (error) {
        showNotification('Error al actualizar instructor', 'error');
    }
}

async function deleteInstructor(id) {
    if (confirm('¿Está seguro de eliminar este instructor?')) {
        try {
            await apiService.deleteInstructor(id);
            showNotification('Instructor eliminado exitosamente', 'success');
            await loadAllData();
        } catch (error) {
            showNotification('Error al eliminar instructor', 'error');
        }
    }
}

async function editVideo(id) {
    const video = currentData.videos.find(v => v.id === id);
    if (!video) return;

    try {
        const formData = await editVideoForm(video);
        if (formData) {
            await apiService.updateVideo(formData);
            showNotification('Video actualizado exitosamente', 'success');
            await loadAllData();
        }
    } catch (error) {
        showNotification('Error al actualizar video', 'error');
    }
}

async function deleteVideo(id) {
    if (confirm('¿Está seguro de eliminar este video?')) {
        try {
            await apiService.deleteVideo(id);
            showNotification('Video eliminado exitosamente', 'success');
            await loadAllData();
        } catch (error) {
            showNotification('Error al eliminar video', 'error');
        }
    }
}

async function deleteCertificate(id) {
    if (confirm('¿Está seguro de eliminar este certificado?')) {
        try {
            await apiService.deleteCertificate(id);
            showNotification('Certificado eliminado exitosamente', 'success');
            await loadAllData();
        } catch (error) {
            showNotification('Error al eliminar certificado', 'error');
        }
    }
}

function openLoginModal() {
    document.getElementById('loginModal').style.display = 'block';
}

function closeLoginModal() {
    document.getElementById('loginModal').style.display = 'none';
}

function openRegisterModal() {
    document.getElementById('registerModal').style.display = 'block';
}

function closeRegisterModal() {
    document.getElementById('registerModal').style.display = 'none';
}

window.onclick = function(event) {
    const loginModal = document.getElementById('loginModal');
    const registerModal = document.getElementById('registerModal');
    if (event.target == loginModal) {
        loginModal.style.display = 'none';
    }
    if (event.target == registerModal) {
        registerModal.style.display = 'none';
    }
}

function loginUser(name, type) {
    currentUser = { name: name, type: type };
    
    document.querySelector('.auth-buttons').style.display = 'none';
    document.getElementById('userInfo').classList.add('show');
    document.getElementById('userName').textContent = `Bienvenido, ${name}`;
    
    if (type === 'admin') {
        document.getElementById('adminPanel').style.display = 'block';
        document.getElementById('adminPanel').scrollIntoView({ behavior: 'smooth' });
    }
}

function logout() {
    currentUser = null;
    
    document.querySelector('.auth-buttons').style.display = 'flex';
    document.getElementById('userInfo').classList.remove('show');
    document.getElementById('adminPanel').style.display = 'none';
    
    window.scrollTo({ top: 0, behavior: 'smooth' });
}

function showAdminSection(section) {
    const sections = document.querySelectorAll('.admin-section');
    sections.forEach(s => s.classList.remove('active'));
    
    const navButtons = document.querySelectorAll('.admin-nav-btn');
    navButtons.forEach(btn => btn.classList.remove('active'));
    
    document.getElementById(`admin${section.charAt(0).toUpperCase() + section.slice(1)}`).classList.add('active');
    
    event.target.classList.add('active');
}

async function showAddForm(type) {
    let formData = {};
    
    switch(type) {
        case 'course':
            formData = await showCourseForm();
            if (formData) {
                try {
                    await apiService.createCourse(formData);
                    showNotification('Curso creado exitosamente', 'success');
                    await loadAllData();
                } catch (error) {
                    showNotification('Error al crear curso', 'error');
                }
            }
            break;
            
        case 'instructor':
            formData = await showInstructorForm();
            if (formData) {
                try {
                    await apiService.createInstructor(formData);
                    showNotification('Instructor creado exitosamente', 'success');
                    await loadAllData();
                } catch (error) {
                    showNotification('Error al crear instructor', 'error');
                }
            }
            break;
            
        case 'video':
            formData = await showVideoForm();
            if (formData) {
                try {
                    await apiService.createVideo(formData);
                    showNotification('Video creado exitosamente', 'success');
                    await loadAllData();
                } catch (error) {
                    showNotification('Error al crear video', 'error');
                }
            }
            break;
    }
}

function showCourseForm() {
    const name = prompt('Nombre del curso:');
    const description = prompt('Descripción:');
    const durationHours = prompt('Duración en horas:');
    const instructorId = prompt('ID del instructor:');
    
    if (name && description && durationHours && instructorId) {
        return {
            name: name,
            description: description,
            durationHours: parseInt(durationHours),
            instructorId: parseInt(instructorId)
        };
    }
    return null;
}

function showInstructorForm() {
    const name = prompt('Nombre del instructor:');
    const specialty = prompt('Especialidad:');
    const email = prompt('Email:');
    
    if (name && specialty && email) {
        return {
            name: name,
            specialty: specialty,
            email: email
        };
    }
    return null;
}

function showVideoForm() {
    const title = prompt('Título del video:');
    const videoUrl = prompt('URL del video:');
    const courseId = prompt('ID del curso:');
    
    if (title && videoUrl && courseId) {
        return {
            title: title,
            videoUrl: videoUrl,
            courseId: parseInt(courseId)
        };
    }
    return null;
}

function viewCourseDetails(courseId) {
    const course = currentData.courses.find(c => c.id === courseId);
    const instructor = currentData.instructors.find(i => i.id === course.instructorId);
    const videos = currentData.videos.filter(v => v.courseId === courseId);
    
    let details = `Curso: ${course.name}\n`;
    details += `Descripción: ${course.description}\n`;
    details += `Duración: ${course.durationHours} horas\n`;
    details += `Instructor: ${instructor ? instructor.name : 'Sin instructor'}\n`;
    details += `Videos: ${videos.length} video(s)`;
    
    alert(details);
}

function viewCertificate(id) {
    const certificate = currentData.certificates.find(c => c.id === id);
    const user = currentData.users.find(u => u.id === certificate.userId);
    const course = currentData.courses.find(c => c.id === certificate.courseId);
    
    let details = `Certificado #${certificate.id}\n`;
    details += `Estudiante: ${user ? user.name : 'Usuario no encontrado'}\n`;
    details += `Curso: ${course ? course.name : 'Curso no encontrado'}\n`;
    details += `Fecha de emisión: ${new Date(certificate.issuedDate).toLocaleDateString()}`;
    
    alert(details);
}

function setupAnimations() {
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver(function(entries) {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, observerOptions);

    document.querySelectorAll('.course-card').forEach(card => {
        card.style.opacity = '0';
        card.style.transform = 'translateY(20px)';
        card.style.transition = 'opacity 0.6s, transform 0.6s';
        observer.observe(card);
    });

    document.querySelectorAll('.stat-item').forEach(item => {
        item.style.opacity = '0';
        item.style.transform = 'translateY(20px)';
        item.style.transition = 'opacity 0.6s, transform 0.6s';
        observer.observe(item);
    });
}

document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});

function showNotification(message, type = 'success') {
    const notification = document.createElement('div');
    notification.className = `notification notification-${type}`;
    notification.textContent = message;
    notification.style.cssText = `
        position: fixed;
        top: 100px;
        right: 20px;
        background: ${type === 'success' ? '#4CAF50' : '#f44336'};
        color: white;
        padding: 1rem 2rem;
        border-radius: 10px;
        z-index: 3000;
        animation: slideIn 0.3s ease-out;
    `;

    document.body.appendChild(notification);

    setTimeout(() => {
        notification.remove();
    }, 3000);
}

const style = document.createElement('style');
style.textContent = `
    @keyframes slideIn {
        from {
            transform: translateX(100%);
            opacity: 0;
        }
        to {
            transform: translateX(0);
            opacity: 1;
        }
    }
`;
document.head.appendChild(style);

function renderInstructorsGrid() {
    const instructorsGrid = document.getElementById('instructorsGrid');
    if (!instructorsGrid) return;

    instructorsGrid.innerHTML = '';
    
    currentData.instructors.forEach(instructor => {
        instructorsGrid.innerHTML += `
            <div class="course-card">
                <div class="course-icon">👨‍🏫</div>
                <h3>${instructor.name}</h3>
                <p><strong>Especialidad:</strong> ${instructor.specialty}</p>
                <p><strong>Email:</strong> ${instructor.email}</p>
                <a href="mailto:${instructor.email}" class="btn btn-primary">Contactar</a>
            </div>
        `;
    });
}

function updateStatistics() {
    const totalUsersEl = document.getElementById('totalUsers');
    const totalInstructorsEl = document.getElementById('totalInstructors');
    const totalCoursesEl = document.getElementById('totalCourses');
    const totalCertificatesEl = document.getElementById('totalCertificates');
    
    if (totalUsersEl) totalUsersEl.textContent = currentData.users.length;
    if (totalInstructorsEl) totalInstructorsEl.textContent = currentData.instructors.length;
    if (totalCoursesEl) totalCoursesEl.textContent = currentData.courses.length;
    if (totalCertificatesEl) totalCertificatesEl.textContent = currentData.certificates.length;
}

function hideLoadingIndicators() {
    const loadingElements = document.querySelectorAll('.loading');
    loadingElements.forEach(el => el.style.display = 'none');
}

async function showAddForm(type) {
    let formData = {};
    
    switch(type) {
        case 'course':
            formData = await showAdvancedCourseForm();
            if (formData) {
                try {
                    await apiService.createCourse(formData);
                    showNotification('Curso creado exitosamente', 'success');
                    await loadAllData();
                    updateStatistics();
                } catch (error) {
                    showNotification('Error al crear curso', 'error');
                }
            }
            break;
            
        case 'instructor':
            formData = await showInstructorForm();
            if (formData) {
                try {
                    await apiService.createInstructor(formData);
                    showNotification('Instructor creado exitosamente', 'success');
                    await loadAllData();
                    updateStatistics();
                } catch (error) {
                    showNotification('Error al crear instructor', 'error');
                }
            }
            break;
            
        case 'video':
            formData = await showAdvancedVideoForm();
            if (formData) {
                try {
                    await apiService.createVideo(formData);
                    showNotification('Video creado exitosamente', 'success');
                    await loadAllData();
                } catch (error) {
                    showNotification('Error al crear video', 'error');
                }
            }
            break;
            
        case 'certificate':
            formData = await showAdvancedCertificateForm();
            if (formData) {
                try {
                    await apiService.createCertificate(formData);
                    showNotification('Certificado creado exitosamente', 'success');
                    await loadAllData();
                    updateStatistics();
                } catch (error) {
                    showNotification('Error al crear certificado', 'error');
                }
            }
            break;
    }
}

function showCertificateForm() {
    const userId = prompt('ID del usuario:');
    const courseId = prompt('ID del curso:');
    
    if (userId && courseId) {
        return {
            userId: parseInt(userId),
            courseId: parseInt(courseId)
        };
    }
    return null;
}