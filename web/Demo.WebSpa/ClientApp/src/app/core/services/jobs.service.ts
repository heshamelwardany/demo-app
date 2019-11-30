import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { config } from '../config';

@Injectable({
  providedIn: 'root'
})
export class JobsService {

  constructor(
    private apiService: ApiService
    ) { }

    getAllJobs() {
      return this.apiService.fetch(config.JobsApi.BasePath + config.JobsApi.GetAllJobs);
    }
}
