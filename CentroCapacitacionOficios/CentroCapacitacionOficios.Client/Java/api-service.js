class ApiService {
    constructor() {
        this.baseUrl = CONFIG.API_BASE_URL;
    }

    async makeRequest(url, options = {}) {
        try {
            const response = await fetch(url, {
                headers: {
                    'Content-Type': 'application/json',
                    ...options.headers
                },
                ...options
            });

            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }

            return await response.json();
        } catch (error) {
            console.error('API request failed:', error);
            throw error;
        }
    }

    async getAllUsers() {
        return await this.makeRequest(`${this.baseUrl}/users`);
    }

    async getUserById(id) {
        return await this.makeRequest(`${this.baseUrl}/users/${id}`);
    }

    async createUser(userData) {
        return await this.makeRequest(`${this.baseUrl}/users`, {
            method: 'POST',
            body: JSON.stringify(userData)
        });
    }

    async updateUser(userData) {
        return await this.makeRequest(`${this.baseUrl}/users`, {
            method: 'PUT',
            body: JSON.stringify(userData)
        });
    }

    async deleteUser(id) {
        return await this.makeRequest(`${this.baseUrl}/users/${id}`, {
            method: 'DELETE'
        });
    }

    async getAllCourses() {
        return await this.makeRequest(`${this.baseUrl}/courses`);
    }

    async getCourseById(id) {
        return await this.makeRequest(`${this.baseUrl}/courses/${id}`);
    }

    async createCourse(courseData) {
        return await this.makeRequest(`${this.baseUrl}/courses`, {
            method: 'POST',
            body: JSON.stringify(courseData)
        });
    }

    async updateCourse(courseData) {
        return await this.makeRequest(`${this.baseUrl}/courses`, {
            method: 'PUT',
            body: JSON.stringify(courseData)
        });
    }

    async deleteCourse(id) {
        return await this.makeRequest(`${this.baseUrl}/courses/${id}`, {
            method: 'DELETE'
        });
    }

    async getAllInstructors() {
        return await this.makeRequest(`${this.baseUrl}/instructors`);
    }

    async getInstructorById(id) {
        return await this.makeRequest(`${this.baseUrl}/instructors/${id}`);
    }

    async createInstructor(instructorData) {
        return await this.makeRequest(`${this.baseUrl}/instructors`, {
            method: 'POST',
            body: JSON.stringify(instructorData)
        });
    }

    async updateInstructor(instructorData) {
        return await this.makeRequest(`${this.baseUrl}/instructors`, {
            method: 'PUT',
            body: JSON.stringify(instructorData)
        });
    }

    async deleteInstructor(id) {
        return await this.makeRequest(`${this.baseUrl}/instructors/${id}`, {
            method: 'DELETE'
        });
    }

    async getAllVideos() {
        return await this.makeRequest(`${this.baseUrl}/videos`);
    }

    async getVideoById(id) {
        return await this.makeRequest(`${this.baseUrl}/videos/${id}`);
    }

    async createVideo(videoData) {
        return await this.makeRequest(`${this.baseUrl}/videos`, {
            method: 'POST',
            body: JSON.stringify(videoData)
        });
    }

    async updateVideo(videoData) {
        return await this.makeRequest(`${this.baseUrl}/videos`, {
            method: 'PUT',
            body: JSON.stringify(videoData)
        });
    }

    async deleteVideo(id) {
        return await this.makeRequest(`${this.baseUrl}/videos/${id}`, {
            method: 'DELETE'
        });
    }

    async getAllCertificates() {
        return await this.makeRequest(`${this.baseUrl}/certificates`);
    }

    async getCertificateById(id) {
        return await this.makeRequest(`${this.baseUrl}/certificates/${id}`);
    }

    async createCertificate(certificateData) {
        return await this.makeRequest(`${this.baseUrl}/certificates`, {
            method: 'POST',
            body: JSON.stringify(certificateData)
        });
    }

    async updateCertificate(certificateData) {
        return await this.makeRequest(`${this.baseUrl}/certificates`, {
            method: 'PUT',
            body: JSON.stringify(certificateData)
        });
    }

    async deleteCertificate(id) {
        return await this.makeRequest(`${this.baseUrl}/certificates/${id}`, {
            method: 'DELETE'
        });
    }
}

const apiService = new ApiService();