## .Net Core API (Projects-Designers Management)
##### .Net Core | C# | Entity Framework | Swagger
-- --

API created to learn and become familiar with .Net Core API structure and Swagger/Postman workflow.

## Request list:
###### ProjectController
- GET: http://localhost:5000/api/project - Show all projects from db.
- GET: http://localhost:5000/api/project/{project-id} - Show specified project by ID.
- POST: http://localhost:5000/api/project - Add new project.
- PUT: http://localhost:5000/api/project/{project-name} - Update project by specified project name.
- DELETE: http://localhost:5000/api/project/{project-id} - Delete project by specified project id.
###### DesignerController
- GET: http://localhost:5000/api/project/{project-id}/designers - Show all designers whose works on specified project by project id.
- POST: http://localhost:5000/api/project/{project-id}/designers - Assign designer to project by specified project id.
- DELETE: http://localhost:5000/api/project/{project-id}/designers - Remove all designers from project by specified project id.
- DELETE: http://localhost:5000/api/project/{project-id}/designers/{designer-id} - Remove designer by specified designer id from project by specified project id.

-- --
## Examples from Postman
![](http://imgurl.pl/img2/get-designers-from-spec-proj_5e50496739213.jpg)
![](http://imgurl.pl/img2/get-proj-by-id_5e504967393cc.jpg)
![](http://imgurl.pl/img2/post-project_5e5049673953b.jpg)