import type IPermission from '@/interfaces/permission.interface'
import http from '../services/http-common'

class PermissionDataService {
  getAll(): Promise<any> {
    return http.get('/permissions')
  }

  get(id: number): Promise<any> {
    return http.get(`/permissions/${id}`)
  }

  create(data: IPermission): Promise<any> {
    return http.post('/permissions', data)
  }

  update(id: number, data: IPermission): Promise<any> {
    return http.put(`/permissions/${id}`, data)
  }

  delete(id: number): Promise<any> {
    return http.delete(`/permissions/${id}`)
  }
}

export default new PermissionDataService()
