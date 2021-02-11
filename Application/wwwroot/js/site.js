// This here is like the jquery $.ajax, but uses the javascript fetch api instead of the xml request class that the jquery uses.
// use in async functions like 'await MakeRequest("Controller/Get", "GET", { itemID: 5 });'
async function MakeRequest(url, type, data) {
    try {
        let request = await fetch(url, {
            method: type,
            headers: {
                'Content-Type': 'application/json' // TODO: have custom ability here for req types :)
            },
            body: data != null ? JSON.stringify(data) : undefined
        });
        let response = await request.json();

        if (response.success)
            return response;

        throw "Reponse success is false, server message: " + (response?.message ?? "");
    }
    catch (e) {
        return {
            success: false,
            message: e
        };
    }

}