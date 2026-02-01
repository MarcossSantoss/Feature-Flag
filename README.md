# Feature Flag System

This project is a simple **Feature Flag system with percentage-based control**, created for study and backend architecture practice.

The main goal is to enable gradual feature rollout without requiring new deployments.

The backend is built with **ASP.NET Core** and the frontend with **Angular**.

---

## About the project

Instead of using only ON/OFF feature flags, this system works with a **rollout percentage (0 to 100)**.

This approach is commonly used in real-world systems to reduce risk when releasing new features.

---

## How it works

Each feature has a configurable percentage:

- `0%` → feature disabled
- `100%` → feature fully enabled
- intermediate values enable the feature for part of the users

The decision logic lives in the backend and is consumed by the frontend.

The goal is to ensure:
- consistent user experience
- predictable behavior
- centralized control

---

## Application structure

The project is split into two main parts:

### Backend
- Handles business rules
- Manages Feature Flags and rollout percentages
- Exposes a REST API

### Frontend
- Built with Angular
- Consumes the API
- Shows or hides features based on configuration
- Includes an admin area to update rollout values

---

## Admin area

The admin area allows:

- Updating feature rollout percentages
- Saving configuration changes
- Immediately affecting end-user behavior

Access is restricted to authorized users.

---

## Architecture

The backend follows a **Clean Architecture** approach, organized into:

- Api
- Application
- Domain
- Infrastructure

This structure helps with maintenance and future improvements.

---

## Tech stack

**Backend**
- ASP.NET Core
- C#
- Entity Framework Core

**Frontend**
- Angular
- TypeScript
- HTML
- CSS

---