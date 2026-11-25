// Copyright © 2026 Nox. All rights reserved.
import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';

// Free license key from https://novnox.dev/license/ (removes the license notice; not needed on localhost):
// import { setLicenseKey } from '@novnox/grid';
// setLicenseKey('NOX1....');

bootstrapApplication(App, appConfig).catch((err) => console.error(err));
