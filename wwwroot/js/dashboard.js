
    const connection =
        new signalR.HubConnectionBuilder()
            .withUrl("/liveData")
            .build();

    connection.on(
        "ReceivePriceUpdate",
        function (data)
        {
            console.log("here");
            const symbol =
                data.symbol.replace("/", "-");

            // Update bid/ask

            const bidElement =
                document.getElementById(
                    `bid-${symbol}`);

            const askElement =
                document.getElementById(
                    `ask-${symbol}`);

            if (bidElement)
            {
                bidElement.innerText =
                    data.bid.toFixed(5);
            }

            if (askElement)
            {
                askElement.innerText =
                    data.ask.toFixed(5);
            }

            // Update all distances

            const diffElements =
                document.querySelectorAll(
                    `[id^='diff-${symbol}']`);

            diffElements.forEach(el =>
            {
                const level =
                    parseFloat(
                        el.dataset.level);

                const diff =
                    data.bid - level;

                // el.innerText = `${diff >= 0 ? "+" : ""}${diff.toFixed(5)}`
                el.innerText =
                    `${diff >= 0 ? "+" : ""}${diff.toFixed(5)}`;

                el.classList.remove(
                    "positive",
                    "negative");

                el.classList.add(
                    diff >= 0
                        ? "positive"
                        : "negative");
            });
        });

    connection.start();
