const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub/edit/item")
    .build();

function updateSpellTooltip(elementId, spellEntry) {
    console.log(`Updating tooltip ${elementId} with spell ${spellEntry}`);

    connection.invoke("GetSpellInfo", spellEntry, { id: elementId })
        .catch(function (err) {
            return console.error(err.toString());
        });
}

function initializeTooltip() {
    console.log("Initializing tooltip.");

    // Spells
    {
        for (let id = 1; id < 6; id++) {
            let input = $(`#form-spell-id-${id}`);
            let entry = parseInt($(input).val());

            updateSpellTooltip(id, entry);

            $(`#form-spell-id-${id}`).on('input', function () {
                entry = parseInt($(input).val());
                updateSpellTooltip(id, entry);
            });
        }

        connection.on("GetSpellInfoCallback", function (response) {
            console.log(response);
            if (response.success) {
                let id = response.metadata.id;

                $(`#tooltip-spell-${id}`).show();
                $(`#tooltip-spell-desc-${id}`).text(response.object.description);
            }
            else {
                $(`#tooltip-spell-${elementId}`).hide();
            }
        });
    }
}

// Start SignalR connection.
connection.start().then(function () {
    console.log("SignalR connection established");

    initializeTooltip();
}).catch(function (err) {
    return console.error(err.toString());
});

