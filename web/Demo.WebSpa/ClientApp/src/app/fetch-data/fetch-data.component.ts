import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JobsService } from '../core/services/jobs.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public jobs: Job[];

  constructor(jobsService:JobsService) {
    jobsService.getAllJobs().subscribe(result => {
      this.jobs = result;
    }, error => console.error(error));
  }
}

interface Job {
  Title: string;
  Level: string;
}
