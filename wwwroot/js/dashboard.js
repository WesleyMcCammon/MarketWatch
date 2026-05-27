
    const connection =
        new signalR.HubConnectionBuilder()
            .withUrl("/liveData")
            .build();

    connection.on(
        "ReceivePriceUpdate",
        function (data)
        {
            const symbol =
                data.symbol.replace("/", "-");

            const bidElement =
                document.getElementById(
                    `bid-${symbol}`);

            const askElement =
                document.getElementById(
                    `ask-${symbol}`);

            if (bidElement)
            {
                if(data.bid > 0)
                    bidElement.innerText = data.bid.toFixed(5);
            }

            if (askElement)
            {
                if(data.ask > 0)
                    askElement.innerText = data.ask.toFixed(5);
            }

            if (data.bid > 0) {

                const diffElements =
                    document.querySelectorAll(
                        `[id^='diff-${symbol}']`);

                diffElements.forEach(el => {
                    const level =
                        parseFloat(
                            el.dataset.level);

                    const diff =
                        data.bid - level;

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
            }

        });

    connection.start();
