-- +goose Up
-- +goose StatementBegin
CREATE TABLE workflows
(
    event_id          TEXT      NOT NULL,
    data              JSONB,
    concurrency_token TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    PRIMARY KEY (event_id)
);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
-- +goose StatementEnd
