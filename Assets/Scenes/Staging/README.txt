The Staging folder contains Scenes that is being prepared to be copied to ../Production/

This means you shouldn't edit Scenes in the ../Production/ folder, 
this to always keep them safe & free from errors/mistakes.

Ideal workflow:

1. Create features in your Development Scene & put prefabs in logical folders
2. Level Designer creates Scene in ../Staging/ where (s)he uses the previously created prefabs
3. When the Scene is completed in the Staging state, it is copied to Production.

Changes to Scenes in Production:

1. Do your change in ../Staging/
2. Overwrite (or archive) the old Scene in ../Production/
