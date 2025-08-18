const CONFIG = {
    API_BASE_URL: 'https://localhost:7190/api',
    
    ENDPOINTS: {
        USERS: '/users',
        COURSES: '/courses', 
        INSTRUCTORS: '/instructors',
        VIDEOS: '/videos',
        CERTIFICATES: '/certificates'
    },
    
    DEFAULT_ADMIN: {
        email: 'admin@centro.com',
        password: 'admin123'
    },
    
    STORAGE_KEYS: {
        CURRENT_USER: 'centro_current_user',
        AUTH_TOKEN: 'centro_auth_token'
    },
    
    MESSAGES: {
        LOADING: 'Cargando datos...',
        SUCCESS: {
            CREATED: 'Elemento creado exitosamente',
            UPDATED: 'Elemento actualizado exitosamente', 
            DELETED: 'Elemento eliminado exitosamente',
            LOGIN: 'Inicio de sesión exitoso',
            REGISTER: 'Registro exitoso'
        },
        ERRORS: {
            LOAD_FAILED: 'Error al cargar los datos',
            CREATE_FAILED: 'Error al crear el elemento',
            UPDATE_FAILED: 'Error al actualizar el elemento',
            DELETE_FAILED: 'Error al eliminar el elemento',
            LOGIN_FAILED: 'Credenciales incorrectas',
            REGISTER_FAILED: 'Error en el registro',
            CONNECTION_FAILED: 'Error de conexión con el servidor'
        },
        CONFIRMATIONS: {
            DELETE: '¿Está seguro de eliminar este elemento?',
            LOGOUT: '¿Está seguro de cerrar sesión?'
        }
    },
    
    VALIDATION: {
        EMAIL_PATTERN: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
        MIN_PASSWORD_LENGTH: 6,
        MAX_NAME_LENGTH: 150,
        MAX_EMAIL_LENGTH: 200
    }
};

function validateForm(data, rules) {
    const errors = [];
    
    for (const [field, rule] of Object.entries(rules)) {
        const value = data[field];
        
        if (rule.required && (!value || value.trim() === '')) {
            errors.push(`${rule.label} es requerido`);
            continue;
        }
        
        if (value && rule.type === 'email' && !CONFIG.VALIDATION.EMAIL_PATTERN.test(value)) {
            errors.push(`${rule.label} debe tener un formato válido`);
        }
        
        if (value && rule.minLength && value.length < rule.minLength) {
            errors.push(`${rule.label} debe tener al menos ${rule.minLength} caracteres`);
        }
        
        if (value && rule.maxLength && value.length > rule.maxLength) {
            errors.push(`${rule.label} no puede exceder ${rule.maxLength} caracteres`);
        }
        
        if (value && rule.type === 'number' && isNaN(value)) {
            errors.push(`${rule.label} debe ser un número válido`);
        }
    }
    
    return errors;
}

function saveToLocalStorage(key, data) {
    try {
        localStorage.setItem(key, JSON.stringify(data));
    } catch (error) {
        console.error('Error saving to localStorage:', error);
    }
}

function loadFromLocalStorage(key) {
    try {
        const data = localStorage.getItem(key);
        return data ? JSON.parse(data) : null;
    } catch (error) {
        console.error('Error loading from localStorage:', error);
        return null;
    }
}

function clearLocalStorage() {
    try {
        Object.values(CONFIG.STORAGE_KEYS).forEach(key => {
            localStorage.removeItem(key);
        });
    } catch (error) {
        console.error('Error clearing localStorage:', error);
    }
}

function formatDate(dateString) {
    try {
        const date = new Date(dateString);
        return date.toLocaleDateString('es-ES', {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit'
        });
    } catch (error) {
        return 'Fecha inválida';
    }
}

function formatDateTime(dateString) {
    try {
        const date = new Date(dateString);
        return date.toLocaleString('es-ES', {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit',
            hour: '2-digit',
            minute: '2-digit'
        });
    } catch (error) {
        return 'Fecha inválida';
    }
}

function debounce(func, wait) {
    let timeout;
    return function executedFunction(...args) {
        const later = () => {
            clearTimeout(timeout);
            func(...args);
        };
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
    };
}